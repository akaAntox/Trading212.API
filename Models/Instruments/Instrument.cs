using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Instruments;

[JsonConverter(typeof(StringEnumConverter))]
public enum InstrumentType
{
    CRYPTOCURRENCY,
    ETF,
    FOREX,
    FUTURES,
    INDEX,
    STOCK,
    WARRANT,
    CRYPTO,
    CVR,
    CORPACT
}

public class Instrument
{
    public string AddedOn { get; set; }
    [StringLength(3)]
    public string CurrencyCode { get; set; }
    public string Isin { get; set; }
    public decimal MaxOpenQuantity { get; set; }
    public decimal MinTradeQuantity { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Ticker { get; set; }
    public InstrumentType Type { get; set; }
    public long WorkingScheduleId { get; set; }
}
