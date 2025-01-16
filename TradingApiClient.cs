using Newtonsoft.Json;
using Trading212.API.Endpoints;
using Trading212.API.Models.Exchange;

namespace Trading212.API;

public class TradingApiClient : ITradingApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();

    public TradingApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Exchange>> GetExchangesAsync()
    {
        var response = await _httpClient.GetAsync(ApiEndpoints.ExchangeListUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IEnumerable<Exchange>>(content);
    }
}
