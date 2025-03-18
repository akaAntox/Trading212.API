using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

public class HistoryParameters
{
    public long Cursor { get; set; }
    public string Ticker { get; set; }
    public long Limit { get; set; } = 20;
}
