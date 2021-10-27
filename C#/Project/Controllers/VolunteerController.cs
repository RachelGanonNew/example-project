using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Volunteer")]

    public class VolunteerController : ApiController
    {
        [HttpGet]
        [Route("GetAllVolunteers")]
        public List<Dto.VolunteerDto> GetAllVolunteers()
        {
            return Bl.VolunteerBl.GetAllVolunteers();
        }

        [HttpGet]
        [Route("GetVolunteersByIdVolunteering/{id_volunteering}")]
        public List<Dto.VolunteerDto> GetVolunteersByIdVolunteering(int id_volunteering)
        {
            return Bl.VolunteerBl.GetVolunteersByIdVolunteering(id_volunteering);
        }


        [HttpGet]
        [Route("GetVolunteersByIdTenant/{id_tenant}")]
        public List<Dto.VolunteerDto> GetVolunteersByIdTenant(int id_tenant)
        {
            return Bl.VolunteerBl.GetVolunteersByIdTenant(id_tenant);
        }

       
        [HttpGet]
        [Route("GetVolunteerById/{id}")]
        public Dto.VolunteerDto GetVolunteerById(int id)
        {
            return Bl.VolunteerBl.GetVolunteerById(id);
        }


        [HttpPost]
        [Route("PostVolunteer")]
        public void Post(Dto.VolunteerDto volunteerDto)
        {
            Bl.VolunteerBl.PostVolunteer(volunteerDto);
        }

        [HttpPut]
        [Route("PutVolunteer")]
        public void Put(Dto.VolunteerDto volunteerDto)
        {
            Bl.VolunteerBl.PutVolunteer(volunteerDto);
        }

        [Route("DeleteVolunteer/{id}")]
        public void Delete(int id)
        {
            Bl.VolunteerBl.DeleteVolunteer(id);
        }
    }
}
