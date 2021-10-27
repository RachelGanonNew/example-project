using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Professonal")]
    public class ProfessonalController : ApiController
    {
        [HttpGet]
        [Route("GetAllProfessonals")]
        public List<Dto.ProfessonalDto> GetAllProfessonals()
        {
            return Bl.ProfessonalBl.GetAllProfessonals();
        }

        [HttpGet]
        [Route("GetProfessonalById/{id}")]
        public Dto.ProfessonalDto GetProfessonalById(int id)
        {
            return Bl.ProfessonalBl.GetProfessonalById(id);
        }

        [HttpGet]
        [Route("GetProfessonalByTz/{tz}")]
        public Dto.ProfessonalDto GetProfessonalByTz(string tz)
        {
            return Bl.ProfessonalBl.GetProfessonalByTz(tz);
        }

        [HttpPost]
        [Route("PostProfessonal")]
        public void Post(Dto.ProfessonalDto professonalDto)
        {
            Bl.ProfessonalBl.PostProfessonal(professonalDto);
        }

        [HttpPut]
        [Route("PutProfessonal")]
        public void Put(Dto.ProfessonalDto professonalDto)
        {
            Bl.ProfessonalBl.PutProfessonal(professonalDto);
        }

        [Route("DeleteProfessonal/{id}")]
        public void Delete(int id)
        {
            Bl.ProfessonalBl.DeleteProfessonal(id);
        }
    }
}
