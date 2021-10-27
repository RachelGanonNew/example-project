using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MeetingDal
    {
        public static List<Dal.Meeting> GetAllMeeting()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Meeting.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Meeting GetMeetingById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Meeting.Where(meeting => meeting.id_meeting == id).ToList()[0];
            }
            catch{
                return null;
            }
        }
        
        public static List<Dal.Meeting> GetMeetingsOfBuilding(int id_building)
        {
            try{
                List <Dal.Meeting> meetings = ManangementEntitiesSingleton.Instance.Meeting.Where(meeting => meeting.id_building == id_building).ToList();
                return meetings;
            }
            catch{
                return null;
            }
        }

        public static void PutMeeting(Meeting meeting)
        {
            try{
                var entity = GetMeetingById(meeting.id_meeting);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(meeting);
            }
            catch (Exception e){

            }
        }

        public static void PostMeeting(Meeting meeting)
        {
            try{
                ManangementEntitiesSingleton.Instance.Meeting.Add(meeting);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteMeeting(int id)
        {
            try{
                Dal.Meeting itemToRemove = ManangementEntitiesSingleton.Instance.Meeting.Where(x => x.id_meeting == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Meeting.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    
    }
}
