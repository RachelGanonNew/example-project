using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class MeetingBl
    {
        public static List<Dto.MeetingDto> GetAllMeetings()
        {
            return Dto.Convert.MeetingConvert.ConvertDalEntityToDto(
                Dal.MeetingDal.GetAllMeeting());
        }

        public static Dto.MeetingDto GetMeetingById(int id)
        {
            return Dto.Convert.MeetingConvert.ConvertDalEntityToDto(
                Dal.MeetingDal.GetMeetingById(id));
        }

        public static List<Dto.MeetingDto> GetMeetingsOfBuilding(int id_building)
        {
            return Dto.Convert.MeetingConvert.ConvertDalEntityToDto(
                Dal.MeetingDal.GetMeetingsOfBuilding(id_building));
        }

        public static void PutMeeting(Dto.MeetingDto meetingDto)
        {
            Dal.MeetingDal.PutMeeting(
                Dto.Convert.MeetingConvert.ConvertDalDtoToEntity(meetingDto));
        }

        public static void PostMeeting(Dto.MeetingDto meetingDto)
        {
            Dal.MeetingDal.PostMeeting(
                Dto.Convert.MeetingConvert.ConvertDalDtoToEntity(meetingDto));
        }

        public static void DeleteMeeting(int id)
        {
            Dal.MeetingDal.DeleteMeeting(id);
        }
    }
}
