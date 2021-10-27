using Bl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class TenantBl
    {
        public static List<Dto.TenantDto> GetAllTenants()
        {
            return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
                Dal.TenantDal.GetAllTenants());
        }

        public static Dto.TenantDto GetTenantById(int id)
        { 
         return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
             Dal.TenantDal.GetTenantById(id));
        }

        public static List<Dto.TenantDto> GetTenantsOfBuilding(int id_building)
        {
            return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
                Dal.TenantDal.GetTenantsOfBuilding(id_building));
        }

        public static Dto.TenantDto GetTenantByEmailAndTz(string email, string tz)
        {
            return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
                Dal.TenantDal.GetTenantByEmailAndTz(email, tz));
        }
        public static Dto.TenantDto GetTenantByStatus(string id_building)
        {
            return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
                Dal.TenantDal.GetTenantByStatus(id_building));
        }
        public static Dto.TenantDto GetTenantByTz( string tz)
        {
            return Dto.Convert.TenantConvert.ConvertDalEntityToDto(
                Dal.TenantDal.GetTenantByTz( tz));
        }

        public static void PutTenant(Dto.TenantDto tenantDto)
        {
            Dal.TenantDal.PutTenant(
                Dto.Convert.TenantConvert.ConvertDalDtoToEntity(tenantDto));
        }

        public static int PostTenant(Dto.TenantDto tenantDto)
        {
            return Dal.TenantDal.PostTenant(
                Dto.Convert.TenantConvert.ConvertDalDtoToEntity(tenantDto));
        }

        public static void DeleteTenant(int id)
        {
            Dal.TenantDal.DeleteTenant(id);
        }
        
        public static void PostNewTenantNewBuilding(Bl.Model.Address address, Bl.Model.FloorsNumApartmentsNum floorsNumApartmentsNum, Dto.TenantDto tenantDto)
        {
            tenantDto.status = 0;
            int idNewTenant = PostTenant(tenantDto);
            int[] tenants = { idNewTenant };
            Dto.BuildingDto buildingDto = new Dto.BuildingDto()
            {
                street = address.street,
                city = address.city,
                street_num = address.street_num,
                floors_num = floorsNumApartmentsNum.floors_num,
                apartments_num = floorsNumApartmentsNum.apartments_num,
                tenants = tenants,
                id_tenantManager = idNewTenant,
                month_cost = 0,
                cash_box = 0,
                professonal = { }
            };
            int idNewBuilding = Bl.BuildingBl.PostBuilding(buildingDto);
            UpdateIdBuilding(idNewTenant, idNewBuilding);
            }
  
        public static void PostNewTenantOldBuilding(Dto.TenantDto tenantDto, Dto.BuildingDto buildingDto)
        {
            tenantDto.id_building = buildingDto.id_building;
            tenantDto.status = 0;
            PostTenant(tenantDto);
            int idTenant = Dal.TenantDal.GetTenantByTz(tenantDto.tz).id_tenant;
                //SendEmail(buildingDto.id_tenantManager);
            
            Dto.TenantManagerMesseageDto tenantManagerMesseageDto = new Dto.TenantManagerMesseageDto() {
                 id_tenantManager = buildingDto.id_tenantManager,
                 id_building = buildingDto.id_building,
                 description_tenantManager_messeage = "new tenant is waiting for your confirm",
                 tenantManager_messeage_date = DateTime.Today
            };
                Bl.TenantManagerMesseageBl.PostTenantManagerMesseage(tenantManagerMesseageDto);
        }

        public static void UpdateIdBuilding(int idBuilding, int idTenant)
        {
            Dal.TenantDal.UpdateIdBuilding(
                           idBuilding, idTenant);
        }

        public static void ConfrimTenatnt(int idBuilding, int idTenant,int idMessage)
        {
            Bl.BuildingBl.UpdateBuildingTenants(idBuilding, idTenant);
            Dal.TenantDal.UpdateTenantStatus(idTenant, 1);
            Dal.TenantManagerMesseageDal.DeleteTenantManagerMesseage(idMessage);
        }

        public static void NotConfrimTenatnt(int idBuilding, int idTenant, int idMessage)
        {
            //SendMail(idTenant);
            Dal.TenantDal.DeleteTenant(idTenant);
            Dal.TenantManagerMesseageDal.DeleteTenantManagerMesseage(idMessage);
        }

    }
}
