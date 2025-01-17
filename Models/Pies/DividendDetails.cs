using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

public class DividendDetails
{
    public decimal Gained { get; set; }
    public decimal InCash { get; set; }
    public decimal Reinvested { get; set; }
}
