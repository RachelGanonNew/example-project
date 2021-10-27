using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ProfessonalDto
    {
        public int id_professonal { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int[] buildings { get; set; }
        public int? professonal_category { get; set; }
        public int? hour_cost { get; set; }


    }
}
