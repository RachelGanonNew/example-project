using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MeetingVoteDto
    {
        public int id_meeting_vote { get; set; }
        public int id_meeting { get; set; }
        public int id_building { get; set; }
        public string vote_description { get; set; }
    }
}
