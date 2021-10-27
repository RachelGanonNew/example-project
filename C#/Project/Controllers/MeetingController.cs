using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Meeting")]

    public class MeetingController : ApiController
    {
        // GET: api/Meeting
        [HttpGet]
        [Route("GetAllMeetings")]
        public List<Dto.MeetingDto> GetAllMeetings()
        {
            return Bl.MeetingBl.GetAllMeetings();
        }

        [HttpGet]
        [Route("GetMeetingById/{id}")]
        public Dto.MeetingDto GetMeetingById(int id)
        {
            return Bl.MeetingBl.GetMeetingById(id);
        }

        [HttpGet]
        [Route("GetMeetingsOfBuilding/{id_building}")]
        public List <Dto.MeetingDto> GetMeetingsOfBuilding(int id_building)
        {
            return Bl.MeetingBl.GetMeetingsOfBuilding(id_building);
        }

        [HttpPost]
        [Route("PostMeeting")]
        public void Post(Dto.MeetingDto meetingDto)
        {
            Bl.MeetingBl.PostMeeting(meetingDto);
        }

        [HttpPut]
        [Route("PutMeeting")]
        public void Put(Dto.MeetingDto meetingDto)
        {
            Bl.MeetingBl.PutMeeting(meetingDto);
        }

        [Route("DeleteMeeting/{id}")]
        public void Delete(int id)
        {
            Bl.MeetingBl.DeleteMeeting(id);
        }
    }
}
