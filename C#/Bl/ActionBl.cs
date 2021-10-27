using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ActionBl
    {
        public static List<Dto.ActionDto> GetAllActions()
        {
            return Dto.Convert.ActionConvert.ConvertDalEntityToDto(
                Dal.ActionDal.GetAllActions());
        }

        public static Dto.ActionDto GetActionById(int id)
        {
            return Dto.Convert.ActionConvert.ConvertDalEntityToDto(
                Dal.ActionDal.GetActionById(id));
        }

        public static List<Dto.ActionDto> GetActionsOfBuilding(int id_building)
        {
            return Dto.Convert.ActionConvert.ConvertDalEntityToDto(
                Dal.ActionDal.GetActionsOfBuilding(id_building));
        }

        public static List<Dto.ActionDto> GetActionsOfBuildingYear(int id_building, int year)
        {
            return Dto.Convert.ActionConvert.ConvertDalEntityToDto(
                Dal.ActionDal.GetActionsOfBuildingYear(id_building, year));
        }

        public static List<Dto.ActionDto> GetActionsOfBuildingYearMonth(int id_building, int year, int month)
        {
            return Dto.Convert.ActionConvert.ConvertDalEntityToDto(
                Dal.ActionDal.GetActionsOfBuildingYearMonth(id_building, year,month));
        }

        public static void PutAction( Dto.ActionDto actionDto)
        {
            Dal.ActionDal.PutAction(
                Dto.Convert.ActionConvert.ConvertDalDtoToEntity(actionDto));
        }
        public static void PostAction(Dto.ActionDto actionDto)
        {
            Dal.ActionDal.PostAction(
                Dto.Convert.ActionConvert.ConvertDalDtoToEntity(actionDto));
        }

        public static void DeleteAction(int id)
        {
            Dal.ActionDal.DeleteAction(id);
        }
    }
}
