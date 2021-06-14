using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SND.SystemManagementCustomer.HttpIntegration
{
    public class RestService : IRestService
    {
        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient = CreateHttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
            => await _httpClient.GetAsync(endpoint);


        #region Private Methods
        private static HttpClient CreateHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return new HttpClient(handler);
        }

        #endregion Private Methods
    }
}