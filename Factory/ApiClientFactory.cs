using Trading212.API.Configuration;

namespace Trading212.API.Factory;

public static class ApiClientFactory
{
    public static ITradingApiClient Create(bool isDemo)
    {
        var baseUrl = isDemo
            ? "https://demo.trading212.com"
            : "https://live.trading212.com";

        var configuration = new ApiConfiguration { BaseUrl = baseUrl };
        var httpClient = new HttpClient();
        return new TradingApiClient(httpClient, configuration);
    }
}
