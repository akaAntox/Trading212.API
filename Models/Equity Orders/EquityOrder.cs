using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Equity_Orders;

[JsonConverter(typeof(StringEnumConverter))]
public enum EquityOrderStatus
{
    LOCAL,
    UNCONFIRMED,
    CONFIRMED,
    NEW,
    CANCELLING,
    CANCELLED,
    PARTIALLY_FILLED,
    FILLED,
    REJECTED,
    REPLACING,
    REPLACED
}

[JsonConverter(typeof(StringEnumConverter))]
public enum EquityOrderStrategy
{
    QUANTITY,
    VALUE
}

[JsonConverter(typeof(StringEnumConverter))]
public enum EquityOrderType
{
    LIMIT,
    STOP,
    MARKET,
    STOP_LIMIT
}

public class EquityOrder
{
    public DateTime CreationTime { get; set; }
    public decimal FilledQuantity { get; set; }
    public decimal FilledValue { get; set; }
    public long id { get; set; }
    public decimal LimitPrice { get; set; }
    public decimal Quantity { get; set; }
    public EquityOrderStatus Status { get; set; }
    public decimal StopPrice { get; set; }
    public EquityOrderStrategy Strategy { get; set; }
    public string Ticker { get; set; }
    public EquityOrderType Type { get; set; }
    public decimal Value { get; set; }
}
