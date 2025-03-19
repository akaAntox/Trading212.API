using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

[JsonConverter(typeof(StringEnumConverter))]
public enum ExportStatus
{
    QUEUED,
    PROCESSING,
    RUNNING,
    CANCELED,
    FAILED,
    FINISHED
}

public class ReportDataIncluded
{
    public bool IncludeDividends { get; set; }
    public bool includeInterest { get; set; }
    public bool IncludeOrders { get; set; }
    public bool IncludeTransactions { get; set; }

}

public class HistoryExportItem
{
    public List<ReportDataIncluded> DataIncludeds { get; set; }
    public string DownloadLink { get; set; }
    public long ReportId { get; set; }
    public ExportStatus Status { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
}
