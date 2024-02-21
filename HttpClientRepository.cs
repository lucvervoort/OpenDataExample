namespace OpenDataExample
{
    public class HttpClientRepository
    {
        private IHttpClientFactory _httpClientFactory;

        public HttpClientRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var client = _httpClientFactory.CreateClient("HttpClient");
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");
            var responseObject = await response.Content.ReadFromJsonAsync<T>();
            return responseObject;
        }
    }
}
