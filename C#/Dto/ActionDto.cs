using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ActionDto
    {
        public int id_action { get; set; }
        public bool? kind_of_action { get; set; }
        public string action_description { get; set; }
        public DateTime? action_date { get; set; }
        public int? action_sum { get; set; }
        public int? id_tenant { get; set; }
        public int? id_building { get; set; }
        public int? id_action_category { get; set; }

    }
}
