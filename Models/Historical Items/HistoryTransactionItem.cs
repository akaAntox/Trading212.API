using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trading212.API.Models.Historical_Items;

[JsonConverter(typeof(StringEnumConverter))]
public enum TransactionType
{
    WITHDRAW,
    DEPOSIT,
    FEE,
    TRANSFER
}

public class HistoryTransactionItem
{
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public required string Reference { get; set; }
    public TransactionType Type { get; set; }
}
