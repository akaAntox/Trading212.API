using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading212.API.Models.Exchanges;

public class WorkingSchedule
{
    public long Id { get; set; }
    public List<TimeEvent> TimeEvents { get; set; }
}
