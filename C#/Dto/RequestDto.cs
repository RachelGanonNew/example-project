using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class RequestDto
    {
        public int id_request { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int? street_num { get; set; }
        public int? apartment_num { get; set; }
        public int? floor_num { get; set; }
        public int? status { get; set; }

    }
}
