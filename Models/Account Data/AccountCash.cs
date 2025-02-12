using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Account_Data;

public class AccountCash
{
    public decimal? Blocked { get; set; }
    public decimal Free { get; set; }
    public decimal Invested { get; set; }
    public decimal PieCash { get; set; }
    public decimal Ppl { get; set; }
    public decimal Result { get; set; }
    public decimal Total { get; set; }
}
