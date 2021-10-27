using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/MeetingVote")]
    public class MeetingVoteController : ApiController
    {

        [HttpPost]
        [Route("PostMeetingVote")]
        public void Post(Dto.MeetingVoteDto meetingVoteDto)
        {
            Bl.MeetingVoteBl.PostMeetingVote(meetingVoteDto);
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
            Bl.MeetingVoteBl.DeleteMeetingVote(id);
        }
    }
}
