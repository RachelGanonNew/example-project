using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class VolunteeringCategoryConvert
    {
        public static List<VolunteeringCategoryDto> ConvertDalEntityToDto(List<Dal.Volunteering_Category> volunteering_Categories)
        {
            if (volunteering_Categories == null)
                return null;
            List<VolunteeringCategoryDto> volunteeringDtos = volunteering_Categories.Select(s => ConvertDalEntityToDto(s)).ToList();
            return volunteeringDtos;

        }
        public static VolunteeringCategoryDto ConvertDalEntityToDto(Dal.Volunteering_Category volunteering_Category)
        {
            if (volunteering_Category is null)
                return null;
            VolunteeringCategoryDto volunteeringCategoryDto = new VolunteeringCategoryDto()
            {
                id_volunteering_category = volunteering_Category.id_volunteering_category,
                description_volunteering_category = volunteering_Category.description_volunteering_category,
                id_bulding = volunteering_Category.id_bulding,

            };
            return volunteeringCategoryDto;

        }
        public static Dal.Volunteering_Category ConvertDalDtoToEntity(VolunteeringCategoryDto volunteeringCategoryDto)
        {
            try{
                Dal.Volunteering_Category volunteering_Category = new Dal.Volunteering_Category()
                {
                    id_volunteering_category = volunteeringCategoryDto.id_volunteering_category,
                    description_volunteering_category = volunteeringCategoryDto.description_volunteering_category,
                    id_bulding = volunteeringCategoryDto.id_bulding,

                };
                return volunteering_Category;

            }
            catch (Exception e){
                return null;
            }
        }
    }
}
