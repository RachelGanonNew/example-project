using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  public  class BuildingDal
    {

        public static List<Dal.Building> GetAllBuildings()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Building.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Dal.Building GetBuildingById(int id)
        {
            try{
                     return ManangementEntitiesSingleton.Instance.Building.Where(building => building.id_building == id).ToList()[0];
            } catch(Exception e) {
                return null;
            }
        }
        public static Dal.Building GetBuildingByIdBuilding(int id)
        {
            try
            {
                return ManangementEntitiesSingleton.Instance.Building.Where(building => building.id_building == id).ToList()[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Dal.Building GetBuildingByAddres(string city, string street, int? street_num)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Building.Where(
                    building => building.city.Equals(city) &&
                    building.street.Equals(street) &&
                    building.street_num == street_num).ToList()[0];
            }
            catch (Exception e){
                Console.Write(e.ToString());
                return null;
            }
        }
        
        public static void PutBuilding(Building building)
        {
            try{
                var entity = GetBuildingById(building.id_building);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(building);
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateBuildingTenants(int idBuilding, int idTenant)
        {
            try{
                int ind;
                var theBuilding = ManangementEntitiesSingleton.Instance.Building.Where(b => b.id_building == idBuilding).ToList()[0];
                if (!(String.IsNullOrEmpty(theBuilding.tenants)))
                    ind = theBuilding.tenants.Length - 1;
                else { 
                    ind = 0;
                    theBuilding.tenants = "";
                    }    
                theBuilding.tenants = theBuilding.tenants.Insert(ind, (idTenant).ToString());
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine("cant update tenant in building");
            }
        }
        public static int PostBuilding(Building building)
        {
            try{
                ManangementEntitiesSingleton.Instance.Building.Add(building);
                ManangementEntitiesSingleton.Instance.SaveChanges();
                return building.id_building;
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return -1;
            }

        }

        public static void DeleteBuilding(int id)
        {
            try
            {
                Dal.Building itemToRemove = ManangementEntitiesSingleton.Instance.Building.Where(x => x.id_building == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Building.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
