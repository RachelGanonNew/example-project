using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class TenantManagerMesseageConvert
    {
        public static List<TenantManagerMesseageDto> ConvertDalEntityToDto(List<Dal.TenantManager_Messeage> tenantManager_Messeages)
        {
            List<TenantManagerMesseageDto> tenantManagerMesseageDtos = tenantManager_Messeages.Select(m => ConvertDalEntityToDto(m)).ToList();
            return tenantManagerMesseageDtos;

        }

        public static TenantManagerMesseageDto ConvertDalEntityToDto(Dal.TenantManager_Messeage tenantManager_Messeage)
        {
            if (tenantManager_Messeage is null)
                return null;
            TenantManagerMesseageDto tenantManagerMesseageDto = new TenantManagerMesseageDto()
            {
                id_tenantManager_messeage = tenantManager_Messeage.id_tenantManager_messeage,
                id_tenantManager = tenantManager_Messeage.id_tenantManager,
                id_building = tenantManager_Messeage.id_building,
                description_tenantManager_messeage = tenantManager_Messeage.description_tenantManager_messeage,
                tenantManager_messeage_date = tenantManager_Messeage.tenantManager_messeage_date,
            };


            return tenantManagerMesseageDto;

        }


        public static Dal.TenantManager_Messeage ConvertDalDtoToEntity(TenantManagerMesseageDto tenantManagerMesseageDto)
        {
            try{
                Dal.TenantManager_Messeage tenantManager_Messeage = new Dal.TenantManager_Messeage()
                {
                    id_tenantManager_messeage = tenantManagerMesseageDto.id_tenantManager_messeage,
                    id_tenantManager = tenantManagerMesseageDto.id_tenantManager,
                    id_building = tenantManagerMesseageDto.id_building,
                    description_tenantManager_messeage = tenantManagerMesseageDto.description_tenantManager_messeage,
                    tenantManager_messeage_date = tenantManagerMesseageDto.tenantManager_messeage_date,
                };
                return tenantManager_Messeage;

            }
            catch (Exception e){
                return null;
            }
        }
    }
}
