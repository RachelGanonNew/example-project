using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ActionCategoryBl
    {
        public static List<Dto.ActionCategoryDto> GetAllActionCategorys()
        {
            return Dto.Convert.ActionCategoryConvert.ConvertDalEntityToDto(
                Dal.ActionCategoryDal.GetAllActionCategorys());
        }

        public static Dto.ActionCategoryDto GetActionCategoryById(int id)
        {
            return Dto.Convert.ActionCategoryConvert.ConvertDalEntityToDto(
                Dal.ActionCategoryDal.GetActionCategoryById(id));
        }

        public static List<Dto.ActionCategoryDto> GetActionCategoryOfBuilding(int id_building)
        {
            return Dto.Convert.ActionCategoryConvert.ConvertDalEntityToDto(
                Dal.ActionCategoryDal.GetActionCategoryOfBuilding(id_building));
        }

        public static void PutActionCategory(Dto.ActionCategoryDto actionCategoryDto)
        {
            Dal.ActionCategoryDal.PutActionCategory(
                Dto.Convert.ActionCategoryConvert.ConvertDalDtoToEntity(actionCategoryDto));
        }

        public static void PostActionCategory(Dto.ActionCategoryDto actionCategoryDto)
        {
            Dal.ActionCategoryDal.PostActionCategory(
                Dto.Convert.ActionCategoryConvert.ConvertDalDtoToEntity(actionCategoryDto));
        }

        public static void DeleteActionCategory(int id)
        {
            Dal.ActionCategoryDal.DeleteActionCategory(id);
        }



    }
}
