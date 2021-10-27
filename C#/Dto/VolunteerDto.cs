using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class VolunteerDto
    {
        public int id_volunteer { get; set; }
        public int? id_building { get; set; }
        public int? id_tenant { get; set; }
        public int id_volunteering { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool? done { get; set; }

    }
}
