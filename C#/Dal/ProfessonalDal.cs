using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class ProfessonalDal
    {
        public static List<Dal.Professonal> GetAllProfessonals()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal.ToList();
            }
            catch{
                return null;
            }
        }


        public static Dal.Professonal GetProfessonalById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal.Where(professonal => professonal.id_professonal == id).ToList()[0];
            }
            catch{
                return null;
            }
        }


        public static Dal.Professonal GetProfessonalByTz(string tz)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal.Where(professonal => professonal.tz.Equals(tz)).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static void PutProfessonal(Professonal professonal)
        {
            try{
                var entity = GetProfessonalById(professonal.id_professonal);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(professonal);
            }
            catch (Exception e){

            }
        }
    


        public static void PostProfessonal(Professonal professonal)
        {
            try{
                ManangementEntitiesSingleton.Instance.Professonal.Add(professonal);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteProfessonal(int id)
        {
            try{
                Dal.Professonal itemToRemove = ManangementEntitiesSingleton.Instance.Professonal.Where(x => x.id_professonal == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Professonal.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }


    }
}
