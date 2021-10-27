using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MeetingVoteDal
    {
        public static List<Dal.Meeting_vote> GetMeetingVotesOfMeeting(int id_meeting)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Meeting_vote.Where(meetingVote => meetingVote.id_meeting == id_meeting).ToList();
            }
            catch{
                return null;
            }
        }


        public static void PostMeetingVote(Meeting_vote meetingVote)
        {
            try{
                ManangementEntitiesSingleton.Instance.Meeting_vote.Add(meetingVote);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteMeetingVote(int id)
        {
            try{
                Dal.Meeting_vote itemToRemove = ManangementEntitiesSingleton.Instance.Meeting_vote.Where(x => x.id_meeting_vote == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Meeting_vote.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }

}

