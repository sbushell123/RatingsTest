using Newtonsoft.Json;

namespace Ratings.API.DataProviders
{
    public class DataProvider<T> : IDataProvider<T> where T : class
    {
        private readonly IHttpClientFactory _httpClient;
        private string _url;

        public DataProvider(IHttpClientFactory httpClient, string url)
        {
            _httpClient = httpClient;
            _url = url;
        }

        public async Task<T> Get()
        {
            var client = _httpClient.CreateClient();
            
            var response = await client.GetStringAsync(_url);

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
