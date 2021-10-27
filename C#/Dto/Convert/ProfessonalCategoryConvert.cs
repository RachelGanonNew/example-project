using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class ProfessonalCategoryConvert
    {
        public static List<ProfessonalCategoryDto> ConvertDalEntityToDto(List<Dal.Professonal_Category> professonal_Categories)
        {
            List<ProfessonalCategoryDto> ProfessonalCategoryDtos = professonal_Categories.Select(p => ConvertDalEntityToDto(p)).ToList();
            return ProfessonalCategoryDtos;

        }

        public static ProfessonalCategoryDto ConvertDalEntityToDto(Dal.Professonal_Category professonal_Category)
        {
            if (professonal_Category is null)
                return null;

            ProfessonalCategoryDto professonalCategoryDto = new ProfessonalCategoryDto()
            {
                id_professonal_category = professonal_Category.id_professonal_category,
                professonal_category_description = professonal_Category.professonal_category_description,
                id_building = professonal_Category.id_building
            };
            return professonalCategoryDto;

        }


        public static Dal.Professonal_Category ConvertDalDtoToEntity(ProfessonalCategoryDto professonalCategoryDto)
        {
            try{
                Dal.Professonal_Category professonal_Category = new Dal.Professonal_Category()
                {
                    id_professonal_category = professonalCategoryDto.id_professonal_category,
                    professonal_category_description = professonalCategoryDto.professonal_category_description,
                    id_building = professonalCategoryDto.id_building
                };
                return professonal_Category;
            }
            catch (Exception e){
                return null;
            }
        }

    }
}
