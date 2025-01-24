using Microsoft.Extensions.Configuration;

namespace Trading212.API.Factory;

public static class ApiClientFactory
{
    public static ITradingApiClient Create(bool isDemo = false)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<TradingApiClient>()
            .Build();

        var apiKey = configuration["ApiKey"];
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception("API Key is missing in user secrets");
        }

        var baseUrl = isDemo
            ? "https://demo.trading212.com"
            : "https://live.trading212.com";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);
        httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);

        return new TradingApiClient(httpClient);
    }
}
