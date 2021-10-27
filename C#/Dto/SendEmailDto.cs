using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TenantDto
    {
        public int id_tenant { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int? id_building { get; set; }
        public int? apartment_num { get; set; }
        public int? floor_num { get; set; }
        public int? status { get; set; }

        public TenantDto()
        {

        }

    }
}
