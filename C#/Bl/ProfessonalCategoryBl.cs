using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ProfessonalCategoryBl
    {
        public static List<Dto.ProfessonalCategoryDto> GetAllProfessonalCategorys()
        {
            return Dto.Convert.ProfessonalCategoryConvert.ConvertDalEntityToDto(
                Dal.ProfessonalCategoryDal.GetAllProfessonalCategorys());
        }

        public static Dto.ProfessonalCategoryDto GetProfessonalCategoryById(int id)
        {
            return Dto.Convert.ProfessonalCategoryConvert.ConvertDalEntityToDto(
                Dal.ProfessonalCategoryDal.GetProfessonalCategoryById(id));
        }
        
        public static List <Dto.ProfessonalCategoryDto> GetProfessonalCategoryOfBuilding(int id_building)
        {
            return Dto.Convert.ProfessonalCategoryConvert.ConvertDalEntityToDto(
                Dal.ProfessonalCategoryDal.GetProfessonalCategoryOfBuilding(id_building));
        }

        public static void PutProfessonalCategory(Dto.ProfessonalCategoryDto professonalCategoryDto)
        {
            Dal.ProfessonalCategoryDal.PutProfessonalCategory(
                Dto.Convert.ProfessonalCategoryConvert.ConvertDalDtoToEntity(professonalCategoryDto));
        }
        
        public static void PostProfessonalCategory(Dto.ProfessonalCategoryDto professonalCategoryDto)
        {
            Dal.ProfessonalCategoryDal.PostProfessonalCategory(
                Dto.Convert.ProfessonalCategoryConvert.ConvertDalDtoToEntity(professonalCategoryDto));
        }

        public static void DeleteProfessonalCategory(int id)
        {
            Dal.ProfessonalCategoryDal.DeleteProfessonalCategory(id);
        }

    }
}
