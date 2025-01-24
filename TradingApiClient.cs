using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using Trading212.API.Endpoints;
using Trading212.API.Models.Exchange;
using Trading212.API.Models.Instruments;
using Trading212.API.Models.Pies;

namespace Trading212.API;

public class TradingApiClient : ITradingApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private ILogger<TradingApiClient> _logger;

    public TradingApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<IEnumerable<T>> GetRequestAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content.Result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Cannot get {typeof(T)}s: {ex.Message}");
            throw;
        }
    }

    private async Task<IEnumerable<T>> GetRequestWithIdAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content.Result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Cannot get {typeof(T)}s: {ex.Message}");
            throw;
        }
    }

    #region Instruments Metadata
    public async Task<IEnumerable<Exchange>> GetExchangesAsync() => await GetRequestAsync<Exchange>(ApiEndpoints.ExchangeListUrl);
    public async Task<IEnumerable<Instrument>> GetInstrumentsAsync() => await GetRequestAsync<Instrument>(ApiEndpoints.InstrumentListUrl);
    #endregion

    #region Pies
    public async Task<IEnumerable<Pie>> GetPiesAsync() => await GetRequestAsync<Pie>(ApiEndpoints.PiesUrl);

    public async Task<AccountBucket> CreatePieAsync(CreatePieRequest pie)
    { // TODO: check why it's not working (even tho it's working in the API tests with the same payload)
        try
        {
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false }
                }
            };

            var payloadJson = JsonConvert.SerializeObject(pie, jsonSettings);
            var payload = new StringContent(payloadJson, Encoding.Unicode, "application/json");
            Console.WriteLine($"Payload: {JsonConvert.SerializeObject(pie, jsonSettings)}");

            var response = await _httpClient.PostAsync(ApiEndpoints.PiesUrl, payload);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"BadRequest: {response.StatusCode}, Details: {errorContent}");
                throw new HttpRequestException($"Request failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccountBucket>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }

    public Task<object> DeletePieAsync(long id)
    {
        _httpClient.DefaultRequestHeaders.Add("id", id.ToString());
        var response = _httpClient.DeleteAsync(ApiEndpoints.PiesUrl);
        response.Result.EnsureSuccessStatusCode();

        var content = response.Result.Content.ReadAsStringAsync();
        _httpClient.DefaultRequestHeaders.Remove("id");

        return Task.FromResult<object>(content.Result);
    }

    public Task<Pie> GetPieAsync(long id)
    {
        _httpClient.DefaultRequestHeaders.Add("id", id.ToString());
        var response = _httpClient.GetAsync(ApiEndpoints.PiesUrl);
        response.Result.EnsureSuccessStatusCode();
        var content = response.Result.Content.ReadAsStringAsync();
        _httpClient.DefaultRequestHeaders.Remove("id");
        return Task.FromResult(JsonConvert.DeserializeObject<Pie>(content.Result));
    }
    #endregion
}
