using RestSharp;
using TextmagicRest.Model;

namespace TextmagicRest
{
    public partial class Client
    {
        /// <summary>
        /// Ping the API
        /// </summary>
        /// <returns></returns>
        public PingResult Ping()
        {
            var request = new RestRequest();
            request.Resource = "ping";

            var res = Execute<PingResult>(request);
            res.Wait();
            return res.Result;
        }
    }
}
