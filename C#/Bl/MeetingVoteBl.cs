using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class MeetingVoteBl
    {
        public static List<Dto.MeetingVoteDto> GetMeetingVotesOfMeeting(int id_meeting)
        {
            return Dto.Convert.MeetingVoteConvert.ConvertDalEntityToDto(
                Dal.MeetingVoteDal.GetMeetingVotesOfMeeting(id_meeting));
        }

        public static void PostMeetingVote(Dto.MeetingVoteDto meetingVoteDto)
        {
            Dal.MeetingVoteDal.PostMeetingVote(
                Dto.Convert.MeetingVoteConvert.ConvertDalDtoToEntity(meetingVoteDto));
        }

        public static void DeleteMeetingVote(int id)
        {
            Dal.MeetingVoteDal.DeleteMeetingVote(id);
        }
    }
}
