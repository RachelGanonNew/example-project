using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MeetingDto
    {
        public int id_meeting { get; set; }
        public string meeting_subject { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string meeting_description { get; set; }
        public int id_building { get; set; }

    }
}
