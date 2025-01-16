using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading212.API.Models.Exchanges;

namespace Trading212.API.Models.Exchange;

public class Exchange
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<WorkingSchedule> WorkingSchedules { get; set; }
}
