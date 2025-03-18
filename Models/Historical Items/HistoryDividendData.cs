using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

public class HistoryDividendData
{
    public List<HistoryDividendItem> Items { get; set; }
    public string NextPagePath { get; set; }
}
