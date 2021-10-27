using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class VolunteeringDto
    {
        public int id_volunteering { get; set; }
        public int id_building { get; set; }
        public int? id_volunteering_category { get; set; }
        public string volunteering_description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool requred { get; set; }
        public int? min_time { get; set; }
        public int? max_time { get; set; }
        public int? status { get; set; }


    }
}
