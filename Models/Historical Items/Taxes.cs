using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

[JsonConverter(typeof(StringEnumConverter))]
public enum TaxName
{
    COMMISSION_TURNOVER,
    CURRENCY_CONVERSION_FEE,
    FINRA_FEE,
    FRENCH_TRANSACTION_TAX,
    PTM_LEVY,
    STAMP_DUTY,
    STAMP_DUTY_RESERVE_TAX,
    TRANSACTION_FEE
}

public class Taxes
{
    public string FillId { get; set; }
    public TaxName Name { get; set; }
    public decimal Quantity { get; set; }
    public DateTime TimeCharged { get; set; }
}
