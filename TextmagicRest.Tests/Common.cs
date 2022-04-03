using Moq;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace TextmagicRest.Tests
{
    public static class Common
    {
        public static string Username = "csharp-test-username";
        public static string Token = "csharp-test-token";

        public static RestClient CreateClient<T>(string json, ResponseStatus? responseStatus, HttpStatusCode? statusCode) where T : new()
        {
            var resp = new RestResponse<T>()
            {
                ContentType = "application/json",
                ResponseStatus = responseStatus.HasValue ? (ResponseStatus)responseStatus : RestSharp.ResponseStatus.Completed,
                StatusCode = statusCode.HasValue ? (HttpStatusCode)statusCode : HttpStatusCode.OK,
                Content = json
            };

            resp.Data = JsonSerializer.Deserialize<T>(resp);

            var mock = new Mock<RestClient>();
            mock.Setup(x =>  x.ExecuteAsync<T>(It.IsAny<RestRequest>()).GetAwaiter().GetResult())
                .Returns(resp);

            return mock.Object;
        }
    }
}
