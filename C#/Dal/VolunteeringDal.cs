using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class VolunteeringDal
    {
        public static List<Dal.Volunteering> GetAllVolunteering()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Volunteering GetVolunteeringById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering.Where(volunteering => volunteering.id_volunteering == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Volunteering> GetVolunteeringsOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteering.Where(volunteering => volunteering.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }


        public static void PutVolunteering(Volunteering volunteering)
        {
            try{
                var entity = GetVolunteeringById(volunteering.id_volunteering);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(volunteering);
            }
            catch (Exception e){

            }
        }
        public static void PostVolunteering(Volunteering volunteering)
        {
            try
            {
                ManangementEntitiesSingleton.Instance.Volunteering.Add(volunteering);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteVolunteering(int id)
        {
            try{
                Dal.Volunteering itemToRemove = ManangementEntitiesSingleton.Instance.Volunteering.Where(x => x.id_volunteering == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Volunteering.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }
}
