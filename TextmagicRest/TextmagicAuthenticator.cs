using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace TextmagicRest
{
    public class TextmagicAuthenticator : IAuthenticator
    {
        public string Username { set; get; }
        public string Token { set; get; }


        public TextmagicAuthenticator(string username, string token)
        {
            Username = username;
            Token = token;
        }

        public ValueTask Authenticate(RestClient client, RestRequest request)
        {
            client.AddDefaultHeader("X-TM-Username", Username);
            client.AddDefaultHeader("X-TM-Key", Token);
            return new ValueTask(Task.FromResult(client));
        }
    }
}
