using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ProfessonalCategoryDto
    {
        public int id_professonal_category { get; set; }
        public string professonal_category_description { get; set; }
        public int? id_building { get; set; }
    }
}
