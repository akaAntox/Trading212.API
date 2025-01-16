using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Trading212.API.Models.Exchanges;

[JsonConverter(typeof(StringEnumConverter))]
public enum TimeEventType
{
    OPEN,
    CLOSE,
    BREAK_START,
    BREAK_END,
    PRE_MARKET_OPEN,
    AFTER_HOURS_OPEN,
    AFTER_HOURS_CLOSE,
    OVERNIGHT_OPEN
}

public class TimeEvent
{
    public DateTime Date { get; set; }
    public TimeEventType Type { get; set; }
}
