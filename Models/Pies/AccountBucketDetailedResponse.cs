using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trading212.API.Models.Pies;

[JsonConverter(typeof(StringEnumConverter))]
public enum DividendCashAction
{
    REINVEST,
    TO_ACCOUNT_CASH
}

public class AccountBucketDetailedResponse
{
    public DateTime CreationDate { get; set; }
    public DividendCashAction DividendCashAction { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? Goal { get; set; }
    public string Icon { get; set; }
    public long Id { get; set; }
    public decimal? InitialInvestment { get; set; }
    public Dictionary<string, double>? InstrumentShares { get; set; }
    public string Name { get; set; }
    public string? PublicUrl { get; set; }
}
