using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
  public class BuildingBl
    {
        public static List<Dto.BuildingDto> GetAllBuildings()
        {
            List<Dal.Building> buildings = Dal.BuildingDal.GetAllBuildings();
            return Dto.Convert.BuildingConvert.ConvertDalEntityToDto(buildings);          
        }

        public static Dto.BuildingDto GetBuildingById(int id)
        {
            return Dto.Convert.BuildingConvert.ConvertDalEntityToDto(Dal.BuildingDal.GetBuildingById(id));
        }
        public static Dto.BuildingDto GetBuildingByIdBuilding(int id)
        {
            return Dto.Convert.BuildingConvert.ConvertDalEntityToDto(Dal.BuildingDal.GetBuildingByIdBuilding(id));
        }

        public static Dto.BuildingDto GetBuildingByAddres(string city, string street, int? street_num)
        {
            return Dto.Convert.BuildingConvert.ConvertDalEntityToDto(Dal.BuildingDal.GetBuildingByAddres(city, street, street_num));

        }

        public static void PutBuilding(Dto.BuildingDto buildingDto)
        {
            Dal.BuildingDal.PutBuilding(
                            Dto.Convert.BuildingConvert.ConvertDalDtoToEntity(buildingDto));
        }
        

        public static int PostBuilding(Dto.BuildingDto buildingDto)
        {
            return Dal.BuildingDal.PostBuilding(
                            Dto.Convert.BuildingConvert.ConvertDalDtoToEntity(buildingDto));
        }

        public static void DeleteBuilding(int id)
        {
            Dal.BuildingDal.DeleteBuilding(id);
        }

        public static void UpdateBuildingTenants(int idBuilding, int idTenant)
        {
            Dal.BuildingDal.UpdateBuildingTenants(
                           idBuilding, idTenant);
        }

    }
}
