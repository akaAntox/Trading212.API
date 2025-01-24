using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Pies;

public enum InstrumentIssueName
{
    DELISTED,
    SUSPENDED,
    NO_LONGER_TRADABLE,
    MAX_POSITION_SIZE_REACHED,
    APPROACHING_MAX_POSITION_SIZE,
    COMPLEX_INSTRUMENT_APP_TEST_REQUIRED
}

public enum InstrumentIssueSeverity
{
    IRREVERSIBLE,
    REVERSIBLE,
    INFORMATIVE
}

public class InstrumentIssue
{
    public InstrumentIssueName Name { get; set; }
    public InstrumentIssueSeverity Severity { get; set; }
}
