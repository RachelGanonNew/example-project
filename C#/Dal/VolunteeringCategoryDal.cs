using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class VolunteeringCategoryDal
    {
        public static List<Dal.Volunteering_Category> GetAllVolunteeringCategorys()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering_Category.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Volunteering_Category GetVolunteeringCategoryById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering_Category.Where(
                    volunteering_Category => volunteering_Category.id_volunteering_category == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List <Dal.Volunteering_Category> GetVolunteeringCategorysOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering_Category.Where(
                    volunteering_Category => volunteering_Category.id_bulding == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutVolunteeringCategory(Volunteering_Category volunteering_Category)
        {
            try{
                var entity = GetVolunteeringCategoryById(volunteering_Category.id_volunteering_category);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(volunteering_Category);
            }
            catch (Exception e){

            }
        }


        public static void PostVolunteeringCategory(Volunteering_Category volunteering_Category)
        {
            try{
                ManangementEntitiesSingleton.Instance.Volunteering_Category.Add(volunteering_Category);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteVolunteeringCategory(int id)
        {
            try{
                Dal.Volunteering_Category itemToRemove = ManangementEntitiesSingleton.Instance.Volunteering_Category.Where(x => x.id_volunteering_category == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Volunteering_Category.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }
}
