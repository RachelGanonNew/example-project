using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class MeetingVoteConvert
    {
        public static List<MeetingVoteDto> ConvertDalEntityToDto(List<Dal.Meeting_vote> meetingVotes)
        {
            if (meetingVotes == null)
                return null;
            List<MeetingVoteDto> MeetingVoteDtos = meetingVotes.Select(m => ConvertDalEntityToDto(m)).ToList();
            return MeetingVoteDtos;

        }

        public static MeetingVoteDto ConvertDalEntityToDto(Dal.Meeting_vote meetingVote)
        {
            if (meetingVote is null)
                return null;
            MeetingVoteDto meetingVoteDto = new MeetingVoteDto()
            {
                id_meeting_vote = meetingVote.id_meeting_vote,
                id_meeting = meetingVote.id_meeting,
                id_building = meetingVote.id_building,
                vote_description = meetingVote.vote_description
            };
            return meetingVoteDto;

        }


        public static Dal.Meeting_vote ConvertDalDtoToEntity(MeetingVoteDto meetingVoteDto)
        {
            try
            {
                Dal.Meeting_vote meetingVote = new Dal.Meeting_vote()
                {
                    id_meeting_vote = meetingVoteDto.id_meeting_vote,
                    id_meeting = meetingVoteDto.id_meeting,
                    id_building = meetingVoteDto.id_building,
                    vote_description = meetingVoteDto.vote_description,

                };
                return meetingVote;

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}

