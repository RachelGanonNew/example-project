using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class VoteDto
    {
        public int id_vote { get; set; }
        public int id_meeting { get; set; }
        public string vote_subject { get; set; }
        public string vote_description { get; set; }
        public Dictionary<int, int> tenants_vote { get; set; }
        public int id_building { get; set; }
        public int? id_tenant { get; set; }


        //Dictionary<int, string> My_dict1 =new Dictionary<int, string>();

    }
}
