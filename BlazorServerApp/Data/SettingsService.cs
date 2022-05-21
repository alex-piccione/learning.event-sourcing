using LES.Shared.Entities;

namespace BlazorServerApp.Data
{
    public class SettingsService : BaseService
    {
        public SettingsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Currency[]?> ListCurrencies()
        {
            using var client = CreateClient();
            return await client.GetFromJsonAsync<Currency[]>("currency");

            /*
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = CreateClient();

            var currencies = client.etFromJsonAsync<Currency[]>("/currency");

            return currencies != null ? currencies: Task.FromResult(Array.Empty<Currency>());

            /*var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                branches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                getBranchesError = true;
            }

            shouldRender = true;*/

            /*return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());*/
        }

        public async Task Create(string code, string name)
        {
            using var client = CreateClient();
            await client.PostAsJsonAsync("currency", new { Code = code, Name = name }); ;
        }
    }
}