using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trading212.API.Models.Account_Data;
using Trading212.API.Models.Equity_Orders;
using Trading212.API.Models.Exchange;
using Trading212.API.Models.Instruments;
using Trading212.API.Models.Pies;
using Trading212.API.Personal_Portfolio;

namespace Trading212.API;

[JsonConverter(typeof(StringEnumConverter))]
public enum TimeValidity
{
    DAY,
    GOOD_TILL_CANCEL
}

public interface ITradingApiClient
{
    #region Instruments Metadata
    /// <summary>
    /// Fetch all exchanges and their corresponding working schedules that your account has access to
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Exchange>> GetExchangesAsync();
    public Task<IEnumerable<Instrument>> GetInstrumentsAsync();
    #endregion

    #region Pies
    public Task<IEnumerable<Pie>> GetPiesAsync();
    public Task<AccountBucket> CreatePieAsync(CreatePieRequest pie);
    public Task<object> DeletePieAsync(long id);
    public Task<Pie> GetPieAsync(long id);
    //public Task<IEnumerable<string>> UpdatePieAsync(string id, string dividendCashAction, DateTime endDate, int goal, string icon, object instrumentShares, string name);
    //public Task<IEnumerable<string>> DuplicatePieAsync(string id, string icon, string name);
    #endregion

    #region Equity Orders
    public Task<IEnumerable<EquityOrder>> GetEquityOrdersAsync();
    //public Task<IEnumerable<string>> PlaceEquityLimitOrderAsync(decimal limitPrice, int quantity, string ticker, TimeValidity timeValidity);
    //public Task<IEnumerable<string>> PlaceEquityMarketOrderAsync(int quantity, string ticker);
    //public Task<IEnumerable<string>> PlaceEquityStopOrderAsync(int quantity, decimal stopPrice, string ticker, TimeValidity timeValidity);
    //public Task<IEnumerable<string>> PlaceEquityStopLimitOrderAsync(decimal limitPrice, int quantity, decimal stopPrice, string ticker, TimeValidity timeValidity);
    public Task<object> DeleteEquityOrderAsync(long id);
    public Task<EquityOrder> GetEquityOrderAsync(long id);
    #endregion

    #region Account Data
    public Task<AccountCash> GetAccountCashAsync();
    public Task<AccountMetadata> GetAccountInfoAsync();
    #endregion

    #region Personal Portfolio
    public Task<IEnumerable<Position>> GetOpenPositionsAsync();
    //public Task<IEnumerable<string>> GetPositionByTickerAsync(string ticker);
    public Task<Position> GetOpenPositionAsync(long id);
    #endregion

    #region Historical Items
    //public Task<IEnumerable<string>> GetHistoricalOrdersAsync(int? cursor, string? ticker, int? limit = 20);
    //public Task<IEnumerable<string>> GetHistoricalDividendsAsync(int? cursor, string? ticker, int? limit = 20);
    //public Task<IEnumerable<string>> GetHistoricalExportsListAsync();
    //public Task<IEnumerable<string>> ExportCsvList(object dataIncluded, DateTime timeFrom, DateTime timeTo);
    //public Task<IEnumerable<string>> GetHistoricalTransactionsAsync(int? cursor, DateTime time, int? limit = 20);
    #endregion
}
