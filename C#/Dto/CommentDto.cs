using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CommentDto
    {
        public int id_comment { get; set; }
        public int id_meeting { get; set; }
        public int id_tenant { get; set; }
        public string comment_description { get; set; }
        public DateTime comment_date { get; set; }
        public int id_building { get; set; }


    }
}
