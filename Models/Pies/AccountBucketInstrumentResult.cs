using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;

namespace Trading212.API.Models.Pies;

public class AccountBucketInstrumentResult
{
    public decimal CurrentShare { get; set; }
    public decimal ExpectedShare { get; set; }
    public List<InstrumentIssue> Issues { get; set; }
    public decimal OwnedQuantity { get; set; }
    public InvestmentResult Result { get; set; }
    public string Ticker { get; set; }
}
