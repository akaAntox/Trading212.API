using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

public enum Status
{
    AHEAD,
    ON_TRACK,
    BEHIND
}

public class Pie
{
    public decimal Cash { get; set; }
    public DividendDetails DividendDetails { get; set; }
    public long id { get; set; }
    public decimal? Progress { get; set; }
    public InvestmentResult Result { get; set; }
    public Status? Status { get; set; }
}
