using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class VoteBl
    {
        public static List<Dto.VoteDto> GetAllVotes()
        {
            return Dto.Convert.VoteConvert.ConvertDalEntityToDto(
                Dal.VoteDal.GetAllVotes());
        }

        public static List<Dto.VoteDto> GetVotesOfBuilding(int id_building)
        {
            return Dto.Convert.VoteConvert.ConvertDalEntityToDto(
                Dal.VoteDal.GetVotesOfBuilding(id_building));
        }

        public static List< Dto.VoteDto> GetVoteOfIdMeeting(int id_meeting)
        {
            return Dto.Convert.VoteConvert.ConvertDalEntityToDto(
                Dal.VoteDal.GetVoteOfIdMeeting(id_meeting));
        }

        public static Dto.VoteDto GetVoteById(int id)
        {
            return Dto.Convert.VoteConvert.ConvertDalEntityToDto(
                Dal.VoteDal.GetVoteById(id));
        }

        public static void PutVote(Dto.VoteDto voteDto)
        {
            Dal.VoteDal.PutVote(
                Dto.Convert.VoteConvert.ConvertDalDtoToEntity(voteDto));
        }

        public static void PostVote(Dto.VoteDto voteDto)
        {
            Dal.VoteDal.PostVote(
                Dto.Convert.VoteConvert.ConvertDalDtoToEntity(voteDto));
        }

        public static void DeleteVote(int id)
        {
            Dal.VoteDal.DeleteVote(id);
        }
    }
}
