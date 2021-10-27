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

    [RoutePrefix("api/Volunteering")]
    public class VolunteeringController : ApiController
    {
        [HttpGet]
        [Route("GetAllVolunteerings")]
        public List<Dto.VolunteeringDto> GetAllVolunteerings()
        {
            return Bl.VolunteeringBl.GetAllVolunteerings();
        }

        [HttpGet]
        [Route("GetVolunteeringById/{id}")]
        public Dto.VolunteeringDto GetVolunteeringById(int id)
        {
            return Bl.VolunteeringBl.GetVolunteeringById(id);
        }

        [HttpGet]
        [Route("GetVolunteeringsOfBuilding/{id_building}")]
        public List<Dto.VolunteeringDto> GetVolunteeringsOfBuilding(int id_building)
        {
            return Bl.VolunteeringBl.GetVolunteeringsOfBuilding(id_building);
        }

        [HttpPost]
        [Route("PostVolunteering")]
        public void Post(Dto.VolunteeringDto volunteeringDto)
        {
            
            Bl.VolunteeringBl.PostVolunteering(volunteeringDto);
        }

        [HttpPut]
        [Route("PutVolunteering")]
        public void Put(Dto.VolunteeringDto volunteeringDto)
        {
            Bl.VolunteeringBl.PutVolunteering(volunteeringDto);
        }

        [Route("DeleteVolunteering/{id}")]
        public void Delete(int id)
        {
            Bl.VolunteeringBl.DeleteVolunteering(id);
        }
    }
}
