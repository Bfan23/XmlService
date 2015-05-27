using System.Net;

namespace HttpService
{
    public class HttpService : IHttpService
    {
        public string ServiceUrl { get; set; }

        public string GetResponse()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = ServiceUrl;
                string response = webClient.DownloadString(ServiceUrl);

                return response;
            }
        }
    }
}