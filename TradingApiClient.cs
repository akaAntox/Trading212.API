using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using Trading212.API.Endpoints;
using Trading212.API.Models.Equity_Orders;
using Trading212.API.Models.Exchange;
using Trading212.API.Models.Instruments;
using Trading212.API.Models.Pies;

namespace Trading212.API;

public class TradingApiClient(HttpClient httpClient) : ITradingApiClient
{
    private ILogger<TradingApiClient> logger;

    private async Task<IEnumerable<T>> GetAllRequestAsync<T>(string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content.Result);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot get {typeof(T)}s: {ex.Message}");
            throw;
        }
    }

    private async Task<T> GetRequestAsync<T>(string url, long id)
    {
        try
        {
            var response = await httpClient.GetAsync($"{url}/{id.ToString()}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot get {typeof(T)}: {ex.Message}");
            throw;
        }
    }

    private async Task<T> DeleteRequestAsync<T>(string url, long id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"{url}/{id.ToString()}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot delete {typeof(T)}: {ex.Message}");
            throw;
        }
    }

    #region Instruments Metadata
    public async Task<IEnumerable<Exchange>> GetExchangesAsync() => await GetAllRequestAsync<Exchange>(ApiEndpoints.ExchangeListUrl);
    public async Task<IEnumerable<Instrument>> GetInstrumentsAsync() => await GetAllRequestAsync<Instrument>(ApiEndpoints.InstrumentListUrl);
    #endregion

    #region Pies
    public async Task<IEnumerable<Pie>> GetPiesAsync() => await GetAllRequestAsync<Pie>(ApiEndpoints.PiesUrl);

    public async Task<AccountBucket> CreatePieAsync(CreatePieRequest pie)
    {
        try
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } } };
            var payloadJson = JsonConvert.SerializeObject(pie, jsonSettings);
            var payload = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(ApiEndpoints.PiesUrl, payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccountBucket>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<object> DeletePieAsync(long id) => await DeleteRequestAsync<object>(ApiEndpoints.PiesUrl, id);
    public async Task<Pie> GetPieAsync(long id) => await GetRequestAsync<Pie>(ApiEndpoints.PiesUrl, id);
    #endregion

    #region Equity Orders
    public async Task<IEnumerable<EquityOrder>> GetEquityOrdersAsync() => await GetAllRequestAsync<EquityOrder>(ApiEndpoints.EquityOrdersUrl);
    public async Task<object> DeleteEquityOrderAsync(long id) => await DeleteRequestAsync<object>(ApiEndpoints.EquityOrderUrl, id);
    public async Task<EquityOrder> GetEquityOrderAsync(long id) => await GetRequestAsync<EquityOrder>(ApiEndpoints.EquityOrderUrl, id);
    #endregion
}
