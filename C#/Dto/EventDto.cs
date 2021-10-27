using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class EventDto
    {
        public int id_experience { get; set; }
        public DateTime event_date { get; set; }
        public string title { get; set; }
        public int event_building { get; set; }
    }
}
