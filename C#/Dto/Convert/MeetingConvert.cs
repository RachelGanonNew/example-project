using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class MeetingConvert
    {
        public static List<MeetingDto> ConvertDalEntityToDto(List<Dal.Meeting> meetings)
        {
            if (meetings == null)
                return null;
            List<MeetingDto> MeetingDtos = meetings.Select(m => ConvertDalEntityToDto(m)).ToList();
            return MeetingDtos;

        }

        public static MeetingDto ConvertDalEntityToDto(Dal.Meeting meeting)
        {
            if (meeting is null)
                return null;
            MeetingDto meetingDto = new MeetingDto()
            {
                id_meeting = meeting.id_meeting,
                meeting_subject = meeting.meeting_subject,
                start_date = meeting.start_date,
                end_date = meeting.end_date,
                meeting_description = meeting.meeting_description,
                id_building = meeting.id_building,
            };


            return meetingDto;

        }


        public static Dal.Meeting ConvertDalDtoToEntity(MeetingDto meetingDto)
        {
            try{
                Dal.Meeting meeting = new Dal.Meeting()
                {
                    id_meeting = meetingDto.id_meeting,
                    meeting_subject = meetingDto.meeting_subject,
                    start_date = meetingDto.start_date,
                    end_date = meetingDto.end_date,
                    meeting_description = meetingDto.meeting_description,
                    id_building = meetingDto.id_building,

                };
                return meeting;

            }
            catch (Exception e){
                return null;
            }
        }
    
    }
}
