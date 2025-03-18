using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

public class HistoryDividendItem
{
    public decimal Amount { get; set; }
    public decimal AmountInEuro { get; set; }
    public decimal GrossAmountPerShare { get; set; }
    public DateTime PaidOn { get; set; }
    public decimal Quantity { get; set; }
    public string Reference { get; set; }
    public string Ticker { get; set; }
    public string Type { get; set; }
}
