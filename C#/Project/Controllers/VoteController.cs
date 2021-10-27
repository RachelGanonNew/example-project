using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Vote")]
    public class VoteController : ApiController
    {
        [HttpGet]
        [Route("GetAllVotes")]
        public List<Dto.VoteDto> GetAllVotes()
        {
            return Bl.VoteBl.GetAllVotes();
        }

        [HttpGet]
        [Route("GetVotesOfIdBuilding/{id_building}")]
        public List<Dto.VoteDto> GetVotesOfBuilding(int id_building)
        {
            return Bl.VoteBl.GetVotesOfBuilding(id_building);
        }

        [HttpGet]
        [Route("GetVoteByIdMeeting/{id_meeting}")]
        public List< Dto.VoteDto> GetVoteOfIdMeeting(int id_meeting)
        {
            return Bl.VoteBl.GetVoteOfIdMeeting(id_meeting);
        }

        [HttpGet]
        [Route("GetVoteById/{id}")]
        public Dto.VoteDto GetVoteById(int id)
        {
            return Bl.VoteBl.GetVoteById(id);
        }

        [HttpPost]
        [Route("PostVote")]
        public void PostVote(Dto.VoteDto voteDto)
        {
            Bl.VoteBl.PostVote(voteDto);
        }

        [HttpPut]
        [Route("PutVote")]
        public void Put(Dto.VoteDto voteDto)
        {
            Bl.VoteBl.PutVote(voteDto);
        }

        [Route("DeleteVote/{id}")]
        public void Delete(int id)
        {
            Bl.VoteBl.DeleteVote(id);
        }
    }
}
