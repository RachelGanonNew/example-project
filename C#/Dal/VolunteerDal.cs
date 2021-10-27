using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class VolunteerDal
    {
        public static List<Dal.Volunteer> GetAllVolunteers()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteer.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Volunteer GetVolunteerById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteer.Where(volunteer => volunteer.id_volunteer == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Volunteer> GetVolunteersByIdTenant(int id_tenant)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteer.Where(volunteer => volunteer.id_tenant == id_tenant).ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Volunteer> GetVolunteersByIdVolunteering(int id_Volunteering)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Volunteer.Where(volunteer => volunteer.id_volunteering == id_Volunteering).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutVolunteer(Volunteer volunteer)
        {
            try{
                var entity = GetVolunteerById(volunteer.id_volunteer);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(volunteer);
            }
            catch (Exception e){

            }
        }


        public static void PostVolunteer(Volunteer volunteer)
        {
            try{
                ManangementEntitiesSingleton.Instance.Volunteer.Add(volunteer);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteVolunteer(int id)
        {
            try{
                Dal.Volunteer itemToRemove = ManangementEntitiesSingleton.Instance.Volunteer.Where(x => x.id_volunteer == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Volunteer.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }



    }
}
