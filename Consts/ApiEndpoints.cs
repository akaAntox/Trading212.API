namespace Trading212.API.Endpoints;

public class ApiEndpoints
{
    // metadata
    public const string ExchangeListUrl = "/api/v0/equity/metadata/exchanges";
    public const string InstrumentListUrl = "/api/v0/equity/metadata/instruments";
    // pies
    public const string PiesUrl = "/api/v0/equity/pies";
    public const string PieUrl = "/api/v0/equity/pies/{id}";
    public const string DuplicatePie = "/api/v0/equity/pies/{id}/duplicate";
    // equity orders
    public const string EquityOrdersUrl = "/api/v0/equity/orders";
    public const string EquityOrderUrl = "/api/v0/equity/orders/{id}";
    public const string EquityLimitOrderUrl = "/api/v0/equity/orders/limit";
    public const string EquityMarketOrderUrl = "/api/v0/equity/orders/market";
    public const string EquityStopOrderUrl = "/api/v0/equity/orders/stop";
    public const string EquityStopLimitOrderUrl = "/api/v0/equity/orders/stop_limit";
    // account data
    public const string AccountCashUrl = "/api/v0/equity/account/cash";
    public const string AccountInfoUrl = "/api/v0/equity/account/info";
    // personal portfolio
    public const string OpenPositionsUrl = "/api/v0/equity/portfolio";
    public const string PositionByTickerUrl = "/api/v0/equity/portfolio/ticker";
    // historical items
    public const string HistoricalOrdersUrl = "/api/v0/equity/history/orders";
    public const string HistoricalDividendsUrl = "/api/v0/history/dividends";
    public const string HistoricalExportsUrl = "/api/v0/history/exports";
    public const string HistoricalTransactionsUrl = "/api/v0/history/transactions";
}
