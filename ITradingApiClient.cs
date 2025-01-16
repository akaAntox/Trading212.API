using Trading212.API.Models.Exchange;

namespace Trading212.API;

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
    public Task<IEnumerable<Exchange>> GetExchangesAsync();/*
    public Task<IEnumerable<string>> GetInstrumentsAsync();
    #endregion

    #region Pies
    public Task<IEnumerable<string>> GetPiesAsync();
    public Task<IEnumerable<string>> CreatePieAsync(string dividendCashAction, DateTime endDate, int goal, string icon, object instrumentShares, string name);
    public Task<IEnumerable<string>> DeletePieAsync(string id);
    public Task<IEnumerable<string>> GetPieAsync(string id);
    public Task<IEnumerable<string>> UpdatePieAsync(string id, string dividendCashAction, DateTime endDate, int goal, string icon, object instrumentShares, string name);
    public Task<IEnumerable<string>> DuplicatePieAsync(string id, string icon, string name);
    #endregion

    #region Equity Orders
    public Task<IEnumerable<string>> GetEquityOrdersAsync();
    public Task<IEnumerable<string>> PlaceEquityLimitOrderAsync(decimal limitPrice, int quantity, string ticker, TimeValidity timeValidity);
    public Task<IEnumerable<string>> PlaceEquityMarketOrderAsync(int quantity, string ticker);
    public Task<IEnumerable<string>> PlaceEquityStopOrderAsync(int quantity, decimal stopPrice, string ticker, TimeValidity timeValidity);
    public Task<IEnumerable<string>> PlaceEquityStopLimitOrderAsync(decimal limitPrice, int quantity, decimal stopPrice, string ticker, TimeValidity timeValidity);
    public Task<IEnumerable<string>> DeleteEquityOrderAsync(string id);
    public Task<IEnumerable<string>> GetEquityOrderAsync(string id);
    #endregion

    #region Account Data
    public Task<IEnumerable<string>> GetAccountCashAsync();
    public Task<IEnumerable<string>> GetAccountInfoAsync();
    #endregion

    #region Personal Portfolio
    public Task<IEnumerable<string>> GetOpenPositionsAsync();
    public Task<IEnumerable<string>> GetPositionByTickerAsync(string ticker);
    #endregion

    #region Historical Items
    public Task<IEnumerable<string>> GetHistoricalOrdersAsync(int? cursor, string? ticker, int? limit = 20);
    public Task<IEnumerable<string>> GetHistoricalDividendsAsync(int? cursor, string? ticker, int? limit = 20);
    public Task<IEnumerable<string>> GetHistoricalExportsListAsync();
    public Task<IEnumerable<string>> ExportCsvList(object dataIncluded, DateTime timeFrom, DateTime timeTo);
    public Task<IEnumerable<string>> GetHistoricalTransactionsAsync(int? cursor, DateTime time, int? limit = 20);*/
    #endregion
}
