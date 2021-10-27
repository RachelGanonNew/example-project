using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class TenantManagerMesseageBl
    {
        public static List<Dto.TenantManagerMesseageDto> GetAllTenantManagerMesseages()
        {
            return Dto.Convert.TenantManagerMesseageConvert.ConvertDalEntityToDto(
                Dal.TenantManagerMesseageDal.GetAllTenantManagerMesseages());
        }
        
        public static List<Dto.TenantManagerMesseageDto> GetTenantManagerMesseagesOfBuilding(int id_building)
        {
            return Dto.Convert.TenantManagerMesseageConvert.ConvertDalEntityToDto(
                Dal.TenantManagerMesseageDal.GetTenantManagerMesseagesOfBuilding(id_building));
        }
        
        public static Dto.TenantManagerMesseageDto GetTenantManagerMesseageById(int id)
        {
            return Dto.Convert.TenantManagerMesseageConvert.ConvertDalEntityToDto(
                Dal.TenantManagerMesseageDal.GetTenantManagerMesseageById(id));
        }

        public static void PutTenantManagerMesseage(Dto.TenantManagerMesseageDto tenantManagerMesseageDto)
        {
            Dal.TenantManagerMesseageDal.PutTenantManagerMesseage(Dto.Convert.TenantManagerMesseageConvert.ConvertDalDtoToEntity(tenantManagerMesseageDto));
        }
        
        public static void PostTenantManagerMesseage(Dto.TenantManagerMesseageDto tenantManagerMesseageDto)
        {
            Dal.TenantManagerMesseageDal.PostTenantManagerMesseage(Dto.Convert.TenantManagerMesseageConvert.ConvertDalDtoToEntity(tenantManagerMesseageDto));
        }
        
        public static void DeleteTenantManagerMesseage(int id)
        {
            Dal.TenantManagerMesseageDal.DeleteTenantManagerMesseage(id);
        }
    }
}
