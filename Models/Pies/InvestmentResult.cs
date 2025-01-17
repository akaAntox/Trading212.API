using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

public class InvestmentResult
{
    public decimal PriceAvgInvestedValue { get; set; }
    public decimal PriceAvgResult { get; set; }
    public decimal PriceAvgResultCoef { get; set; }
    public decimal PriceAvgValue { get; set; }
}
