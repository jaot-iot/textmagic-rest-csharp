using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TextmagicRest
{
    public partial class Client
    {
        /// <summary>
        /// TextMagic account username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// TextMagic REST API token (https://my.textmagic.com/online/api/rest-api/keys)
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Connection User-Agent
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// TextMagic REST API base URL
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// HTTP client instance
        /// </summary>
        protected RestClient _client;

        /// <summary>
        /// Last request time (to not to exceed maximum 2 requests per second)
        /// </summary>
        protected DateTime _lastExecuted;

        private const string _defaultUserAgent = "textmagic-rest-csharp/{0} (.NET {1}; {2})";

        /// <summary>
        /// Initialize TextMagic REST client instance
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="token">REST API access token (key)</param>
        /// <param name="baseUrl">API base URL</param>
        /// <param name="timeout">Request timeout</param>
        public Client(string username, string token, string baseUrl, int timeout)
        {
            Username = username;
            Token = token;
            BaseUrl = baseUrl;

            System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName(System.Reflection.Assembly.GetExecutingAssembly().FullName);

            RestClientOptions opts = new(baseUrl)
            {
                Timeout = timeout,
                UserAgent = String.Format(_defaultUserAgent, assemblyName.Version, Environment.Version.ToString(), Environment.OSVersion.ToString()),
            };

            _client = new RestClient(opts);
            _client.AddDefaultHeader("Accept-Charset", "utf-8");
            _client.Authenticator = (IAuthenticator)new TextmagicAuthenticator(Username, Token);
        }

        /// <summary>
        /// Initialize TextMagic REST client instance with special instance of RestClient
        /// </summary>
        /// <param name="client">RestClient instance</param>
        public Client(RestClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Initialize TextMagic REST client instance with default baseUrl and timeout
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="token">REST API access token (key)</param>
        public Client(string username, string token)
            : this(username, token, "https://rest.textmagic.com/api/v2")
        {

        }

        /// <summary>
        /// Initialize TextMagic REST client instance with default timeout
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <param name="baseUrl"></param>
        public Client(string username, string token, string baseUrl) : this(username, token, baseUrl, 20000)
        {

        }

        /// <summary>
        /// Check last request execution time and make delay, if needed
        /// </summary>
        protected void checkExecutionTime()
        {
            var diff = DateTime.Now - _lastExecuted;

            if (diff.TotalMilliseconds < 500)
            {
                System.Threading.Thread.Sleep(Convert.ToInt32(500 - diff.TotalMilliseconds));
            }

            _lastExecuted = DateTime.Now;
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual async Task<T> Execute<T>(RestRequest request) where T : new()
        {
            checkExecutionTime();
            request.OnBeforeDeserialization = (resp) =>
            {
                // if HTTP status code >= 400 - create and save ClientException
                if (((int)resp.StatusCode) >= 400)
                {
                    string clientException = "{{ \"ClientException\" : {0} }}";
                    var content = resp.Content;
                    var newJson = string.Format(clientException, content);

                    resp = new RestResponse()
                    {
                        Content = null,
                        RawBytes = Encoding.UTF8.GetBytes(newJson.ToString())
                    };
                }

                // if HTTP status code is 201 No content, add null ClientException to be success
                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    string clientException = "{{ \"ClientException\" : null }}";
                    var content = resp.Content;
                    var newJson = string.Format(clientException, content);
                    resp = new RestResponse()
                    {
                        Content = null,
                        RawBytes = Encoding.UTF8.GetBytes(newJson.ToString()),
                        ContentType = "application/json"
                    };
                }
            };

            var response = await _client.ExecuteAsync<T>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new ClientException("Network error: " + response.StatusDescription);
            }

            if (response.ErrorException != null)
            {
                throw new ClientException("Invalid input: " + response.ErrorMessage, response.ErrorException);
            }

            return response.Data;
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual async Task<RestResponse> Execute(RestRequest request)
        {
            checkExecutionTime();
            return await _client.ExecuteAsync(request);
        }

        /// <summary>
        /// Convert DateTime object to timestamp
        /// </summary>
        /// <param name="dateTime">DateTime object</param>
        /// <returns></returns>
        public static int DateTimeToTimestamp(DateTime dateTime)
        {
            return Convert.ToInt32((dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds);
        }
    }
}
