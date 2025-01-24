using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

public class AccountBucket
{
    public List<AccountBucketInstrumentResult> Instruments { get; set; }
    public AccountBucketDetailedResponse Settings { get; set; }
}
