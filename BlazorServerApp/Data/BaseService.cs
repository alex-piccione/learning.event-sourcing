namespace BlazorServerApp.Data
{
    public abstract class BaseService
    {
        private IHttpClientFactory httpClientFactory;

        protected HttpClient CreateClient() {
            return httpClientFactory.CreateClient("web api");
        }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}
