using Newtonsoft.Json;
using Trading212.API.Endpoints;
using Trading212.API.Models.Exchange;
using Trading212.API.Models.Instruments;
using Trading212.API.Models.Pies;

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

    public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
    {
        var response = await _httpClient.GetAsync(ApiEndpoints.InstrumentListUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Instrument>>(content);
    }

    public async Task<IEnumerable<Pie>> GetPiesAsync()
    {
        var response = await _httpClient.GetAsync(ApiEndpoints.PiesUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Pie>>(content);
    }
}
