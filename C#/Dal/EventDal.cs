using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class EventDal
    {

        public static List<Dal.experience> GetEventsOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.experience.Where(comment => comment.event_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PostEvent(experience events)
        {
            try{
                ManangementEntitiesSingleton.Instance.experience.Add(events);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }


    }
}
