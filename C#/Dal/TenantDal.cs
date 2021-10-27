using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TenantDal
    {
        //return the DAL list off tenants before cocnvert
        public static List<Dal.Tenant> GetAllTenants()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Tenant.ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Tenant> GetTenantsOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Tenant.Where(tenant => tenant.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Tenant GetTenantById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Tenant.Where(tenant => tenant.id_tenant == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static Dal.Tenant GetTenantByEmailAndTz(string email, string tz)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Tenant.Where(tenant => tenant.email.Equals(email) && tenant.tz.Equals(tz) && tenant.status != 3).ToList()[0];
                // return ManangementEntitiesSingleton.Instance.Tenants.Where(tenant => tenant.email.Equals(email) && tenant.tz.Equals(tz)).ToList()[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Dal.Tenant GetTenantByStatus(string id_building)
        {
            try
            {
                var t = ManangementEntitiesSingleton.Instance.Tenant.Where(tenant => tenant.id_building.Equals(id_building)).ToArray()[0];
                return t;
                //return ManangementEntitiesSingleton.Instance.Tenants.Where(tenant => tenant.id_building.Equals(id_building)).ToArray()[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Dal.Tenant GetTenantByTz( string tz)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Tenant.Where(tenant => tenant.tz.Equals(tz)).ToList()[0];
            }
            catch 
            {
                return null;
            }
        }

        public static void PutTenant(Tenant tenant)
        {
            try{
                var entity = GetTenantById(tenant.id_tenant);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(tenant);
            }
            catch (Exception e){

            }
        }

        public static int PostTenant(Tenant tenant)
        {
            try{
                ManangementEntitiesSingleton.Instance.Tenant.Add(tenant);
                ManangementEntitiesSingleton.Instance.SaveChanges();
                return tenant.id_tenant;
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} throws Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return -1;
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return -1;
            }

        }

        public static void DeleteTenant(int id)
        {
            try
            {
                Dal.Tenant itemToRemove = ManangementEntitiesSingleton.Instance.Tenant.Where(x => x.id_tenant == id).ToList()[0];
                if (itemToRemove != null) { 
                    ManangementEntitiesSingleton.Instance.Tenant.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    
    public static void UpdateTenantStatus(int idTenant, int status)
        {
            Tenant theTenant = ManangementEntitiesSingleton.Instance.Tenant.Where(t => t.id_tenant == idTenant).ToList()[0];
            theTenant.status = status;
            ManangementEntitiesSingleton.Instance.SaveChanges();
        }

    public static void UpdateIdBuilding(int idTenant, int idBuilding)
        {
            Tenant theTenant = ManangementEntitiesSingleton.Instance.Tenant.Where(t => t.id_tenant == idTenant).ToList()[0];
            theTenant.id_building = idBuilding;
            ManangementEntitiesSingleton.Instance.SaveChanges();
        }


    }
}
