using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

//{
//"dividendCashAction": "REINVEST",
//"endDate": "2019-08-24T14:15:22Z",
//"goal": 0,
//"icon": "string",
//"instrumentShares": {
//"AAPL_US_EQ": 0.5,
//"MSFT_US_EQ": 0.5
//},
//"name": "string"
//}
public class CreatePieRequest
{
    public DividendCashAction DividendCashAction { get; set; }
    public DateTime EndDate { get; set; }
    public long Goal { get; set; }
    public string Icon { get; set; }
    public Dictionary<string, double> InstrumentShares { get; set; }
    public string Name { get; set; }
}