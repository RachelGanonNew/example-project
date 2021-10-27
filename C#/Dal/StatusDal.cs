using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class StatusDal
    {
        public static List<Dal.Status> GetAllStatuses()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Status.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Status GetStatusById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Status.Where(action => action.id_status == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static void PutStatus(Status status)
        {
            try{
                var entity = GetStatusById(status.id_status);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(status);
            }
            catch (Exception){

            }
        }
        
        public static void PostStatus(Status status)
        {
            try{
                ManangementEntitiesSingleton.Instance.Status.Add(status);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteStatus(int id)
        {
            try{
                Dal.Status itemToRemove = ManangementEntitiesSingleton.Instance.Status.Where(x => x.id_status == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Status.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }
}
