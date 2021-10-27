using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class VoteDal
    {
        public static List<Dal.Vote> GetAllVotes()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Vote.ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Vote> GetVotesOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Vote.Where(vote => vote.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }


        public static Dal.Vote GetVoteById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Vote.Where(vote => vote.id_vote == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Vote> GetVoteOfIdMeeting(int id_meeting)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Vote.Where(vote => vote.id_meeting == id_meeting).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutVote(Vote vote)
        {
            try{
                var entity = GetVoteById(vote.id_vote);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(vote);
            }
            catch (Exception e){

            }
        }

        public static void PostVote(Vote vote)
        {
            try{
                ManangementEntitiesSingleton.Instance.Vote.Add(vote);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteVote(int id)
        {
            try{
                Dal.Vote itemToRemove = ManangementEntitiesSingleton.Instance.Vote.Where(x => x.id_vote == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Vote.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
