using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class TenantConvert
    {

        public static List<TenantDto> ConvertDalEntityToDto(List<Dal.Tenant> tenants)
        {
            if (tenants == null)
                return null;
            List<TenantDto> TenantDtos = tenants.Select(t => ConvertDalEntityToDto(t)).ToList();
            return TenantDtos;

        }

        public static TenantDto ConvertDalEntityToDto(Dal.Tenant tenant)
        {
            if(tenant is null)
                return null;
                TenantDto TenantDto = new TenantDto()
                {
                    id_tenant = tenant.id_tenant,
                    first_name = tenant.first_name,
                    last_name = tenant.last_name,
                    tz = tenant.tz,
                    phone = tenant.phone,
                    email = tenant.email,
                    id_building = tenant.id_building,
                    apartment_num = tenant.apartment_num,
                    floor_num = tenant.floor_num,
                    status = tenant.status,
                };

            
            return TenantDto;

        }


        public static Dal.Tenant ConvertDalDtoToEntity(TenantDto tenantDto)
        {
            try
            {
                Dal.Tenant tenant = new Dal.Tenant()
                {
                    id_tenant = tenantDto.id_tenant,
                    first_name = tenantDto.first_name,
                    last_name = tenantDto.last_name,
                    tz = tenantDto.tz,
                    phone = tenantDto.phone,
                    email = tenantDto.email,
                    id_building = tenantDto.id_building,
                    apartment_num = tenantDto.apartment_num,
                    floor_num = tenantDto.floor_num,
                    status = tenantDto.status,
                };
             return tenant;

            }
            catch(Exception e){
                return null;
            }
        }
    }
}
