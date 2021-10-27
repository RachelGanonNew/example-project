using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class TenantManagerMesseageDal
    {
        public static List<Dal.TenantManager_Messeage> GetAllTenantManagerMesseages()
        {
            try
            {
                return ManangementEntitiesSingleton.Instance.TenantManager_Messeage.ToList();
            }
            catch
            {
                return null;
            }
        }

        public static Dal.TenantManager_Messeage GetTenantManagerMesseageById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.TenantManager_Messeage.Where(
                    tenantManager_Messeage => tenantManager_Messeage.id_tenantManager_messeage == id).ToList()[0];
            }
            catch{
                return null;
            }
        }
        public static List<Dal.TenantManager_Messeage> GetTenantManagerMesseagesOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.TenantManager_Messeage.Where(
                    tenantManager_Messeage => tenantManager_Messeage.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutTenantManagerMesseage(TenantManager_Messeage tenantManager_Messeage)
        {
            try{
                var entity = GetTenantManagerMesseageById(tenantManager_Messeage.id_tenantManager_messeage);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(tenantManager_Messeage);
            }
            catch (Exception e){

            }
        }


        public static void PostTenantManagerMesseage(TenantManager_Messeage tenantManager_Messeage)
        {
            try{
                ManangementEntitiesSingleton.Instance.TenantManager_Messeage.Add(tenantManager_Messeage);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteTenantManagerMesseage(int id)
        {
            try{
                Dal.TenantManager_Messeage itemToRemove = ManangementEntitiesSingleton.Instance.TenantManager_Messeage.Where(
                    x => x.id_tenantManager_messeage == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.TenantManager_Messeage.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
