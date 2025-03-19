using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO.Pipelines;
using System.Text;
using Trading212.API.Endpoints;
using Trading212.API.Models.Account_Data;
using Trading212.API.Models.Equity_Orders;
using Trading212.API.Models.Exchange;
using Trading212.API.Models.Historical_Items;
using Trading212.API.Models.Instruments;
using Trading212.API.Models.Pies;
using Trading212.API.Personal_Portfolio;

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
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content) || content == "[]")
            {
                return Enumerable.Empty<T>();
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            return result ?? Enumerable.Empty<T>();
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot get {typeof(T)}s: {ex.Message}");
            throw;
        }
    }

    private async Task<T> GetSingleRequestAsync<T>(string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);
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

    private async Task<T> GetRequestAsync<T>(string url, long id)
    {
        try
        {
            var response = await httpClient.GetAsync($"{url}/{id.ToString()}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content) || content == "[]")
            {
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
                {
                    return (T)Activator.CreateInstance(typeof(T));
                }
                return default;
            }

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
    public async Task<AccountBucket> DuplicatePieAsync(string id, string icon, string name)
    {
        try
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } } };
            var payloadJson = JsonConvert.SerializeObject(new { icon, name }, jsonSettings);
            var payload = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{ApiEndpoints.PiesUrl}/{id}/duplicate", payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccountBucket>(content);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot duplicate pie: {ex.Message}");
            throw;
        }
    }
    #endregion

    #region Equity Orders
    public async Task<IEnumerable<EquityOrder>> GetEquityOrdersAsync() => await GetAllRequestAsync<EquityOrder>(ApiEndpoints.EquityOrdersUrl);
    public async Task<object> DeleteEquityOrderAsync(long id) => await DeleteRequestAsync<object>(ApiEndpoints.EquityOrderUrl, id);
    public async Task<EquityOrder> GetEquityOrderAsync(long id) => await GetRequestAsync<EquityOrder>(ApiEndpoints.EquityOrderUrl, id);
    #endregion

    #region Account Data
    public async Task<AccountCash> GetAccountCashAsync() => await GetSingleRequestAsync<AccountCash>(ApiEndpoints.AccountCashUrl);
    public async Task<AccountMetadata> GetAccountInfoAsync() => await GetSingleRequestAsync<AccountMetadata>(ApiEndpoints.AccountInfoUrl);
    #endregion

    #region Personal Portfolio
    public async Task<IEnumerable<Position>> GetOpenPositionsAsync() => await GetAllRequestAsync<Position>(ApiEndpoints.OpenPositionsUrl);
    public async Task<Position> GetPositionByTickerAsync(string ticker)
    {
        try
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } } };
            var payloadJson = JsonConvert.SerializeObject(new { ticker }, jsonSettings);
            var payload = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(ApiEndpoints.PositionByTickerUrl, payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Position>(content);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot get position by ticker: {ex.Message}");
            throw;
        }
    }
    public async Task<Position> GetOpenPositionAsync(long id) => await GetRequestAsync<Position>(ApiEndpoints.OpenPositionsUrl, id);
    #endregion

    #region Historical Items
    public async Task<HistoryOrderData> GetHistoricalOrdersAsync(int? cursor, string? ticker, int? limit = 20) => await GetSingleRequestAsync<HistoryOrderData>($"{ApiEndpoints.HistoricalOrdersUrl}?cursor={cursor}&ticker={ticker}&limit={limit}");
    public async Task<HistoryDividendData> GetHistoricalDividendsAsync(int? cursor, string? ticker, int? limit = 20) => await GetSingleRequestAsync<HistoryDividendData>($"{ApiEndpoints.HistoricalDividendsUrl}?cursor={cursor}&ticker={ticker}&limit={limit}");
    public async Task<IEnumerable<HistoryExportItem>> GetHistoricalExportsListAsync() => await GetAllRequestAsync<HistoryExportItem>(ApiEndpoints.HistoricalExportsUrl);
    public async Task<long> ExportCsvList(ReportDataIncluded dataIncluded, DateTime timeFrom, DateTime timeTo)
    {
        try
        {
            timeFrom = timeFrom.ToUniversalTime();
            timeTo = timeTo.ToUniversalTime();

            var jsonSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } } };
            var payloadJson = JsonConvert.SerializeObject(new { dataIncluded, timeFrom, timeTo }, jsonSettings);
            var payload = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(ApiEndpoints.HistoricalExportsUrl, payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<long>(content);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot export CSV: {ex.Message}");
            throw;
        }
    }
    public async Task<HistoryTransactionData> GetHistoricalTransactionsAsync(int? cursor, DateTime? time, int? limit = 20) => await GetSingleRequestAsync<HistoryTransactionData>($"{ApiEndpoints.HistoricalTransactionsUrl}?cursor={cursor}&time={time.Value:yyyy'-'MM'-'dd'T'HH':'mm':'ssZ}&limit={limit}");
    #endregion
}
