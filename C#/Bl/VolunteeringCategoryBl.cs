using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class VolunteeringCategoryBl
    {
        public static List<Dto.VolunteeringCategoryDto> GetAllVolunteeringCategorys()
        {
            return Dto.Convert.VolunteeringCategoryConvert.ConvertDalEntityToDto(
                Dal.VolunteeringCategoryDal.GetAllVolunteeringCategorys());
        }

        public static List<Dto.VolunteeringCategoryDto> GetVolunteeringCategorysOfBuilding(int id_building)
        {
            return Dto.Convert.VolunteeringCategoryConvert.ConvertDalEntityToDto(
                Dal.VolunteeringCategoryDal.GetVolunteeringCategorysOfBuilding(id_building));
        }

        public static Dto.VolunteeringCategoryDto GetVolunteeringCategoryById(int id)
        {
            return Dto.Convert.VolunteeringCategoryConvert.ConvertDalEntityToDto(
                Dal.VolunteeringCategoryDal.GetVolunteeringCategoryById(id));
        }


        public static void PutVolunteeringCategory(Dto.VolunteeringCategoryDto volunteeringCategoryDto)
        {
            Dal.VolunteeringCategoryDal.PutVolunteeringCategory(
                Dto.Convert.VolunteeringCategoryConvert.ConvertDalDtoToEntity(volunteeringCategoryDto));
        }

        public static void PostVolunteeringCategory(Dto.VolunteeringCategoryDto volunteeringCategoryDto)
        {
            Dal.VolunteeringCategoryDal.PostVolunteeringCategory(
                Dto.Convert.VolunteeringCategoryConvert.ConvertDalDtoToEntity(volunteeringCategoryDto));
        }

        public static void DeleteVolunteeringCategory(int id)
        {
            Dal.VolunteeringCategoryDal.DeleteVolunteeringCategory(id);
        }
    }
}
