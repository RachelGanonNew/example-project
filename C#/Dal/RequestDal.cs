using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class RequestDal
    {
        public static List<Dal.Request> GetAllRequest()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Request.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Request GetRequestById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Request.Where(request => request.id_request == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static void PutRequest(Request request)
        {
            try{
                var entity = GetRequestById(request.id_request);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(request);
            }
            catch (Exception e){

            }
        }

        public static void PostRequest(Request request)
        {
            try{
                ManangementEntitiesSingleton.Instance.Request.Add(request);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteRequest(int id)
        {
            try{
                Dal.Request itemToRemove = ManangementEntitiesSingleton.Instance.Request.Where(x => x.id_request == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Request.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }


    }
}
