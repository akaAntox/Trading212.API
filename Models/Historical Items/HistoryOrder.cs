using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading212.API.Models.Equity_Orders;
using Trading212.API.Personal_Portfolio;

namespace Trading212.API.Models.Historical_Items;

[JsonConverter(typeof(StringEnumConverter))]
public enum FillType
{
    TOTV,
    OTC
}

public class HistoryOrder
{
    public DateTime DateCreated { get; set; }
    public DateTime DateExecuted { get; set; }
    public DateTime DateModified { get; set; }
    public Frontend Executor { get; set; }
    public decimal FillCost { get; set; }
    public long FillId { get; set; }
    public decimal FillPrice { get; set; }
    public decimal FillResult { get; set; }
    public FillType FillType { get; set; }
    public decimal FilledQuantity { get; set; }
    public decimal FilledValue { get; set; }
    public long Id { get; set; }
    public decimal LimitPrice { get; set; }
    public decimal OrderedQuantity { get; set; }
    public decimal OrderedValue { get; set; }
    public long ParentOrder { get; set; }
    public EquityOrderStatus Status { get; set; }
    public decimal StopPrice { get; set; }
    public Taxes Taxes { get; set; }
    public string Ticker { get; set; }
    public TimeValidity TimeValidity { get; set; }
    public EquityOrderType Type { get; set; }
}
