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
    [RoutePrefix("api/VolunteeringCategory")]
    public class VolunteeringCategoryController : ApiController
    {
        [HttpGet]
        [Route("GetAllVolunteeringCategorys")]
        public List<Dto.VolunteeringCategoryDto> GetAllVolunteeringCategory()
        {
            return Bl.VolunteeringCategoryBl.GetAllVolunteeringCategorys();
        }

        [HttpGet]
        [Route("GetVolunteeringCategorysOfBuilding/{id_building}")]
        public List<Dto.VolunteeringCategoryDto> GetVolunteeringCategorysOfBuilding(int id_building)
        {
            return Bl.VolunteeringCategoryBl.GetVolunteeringCategorysOfBuilding(id_building);
        }

        [HttpGet]
        [Route("GetVolunteeringCategoryById/{id}")]
        public Dto.VolunteeringCategoryDto GetVolunteeringCategoryById(int id)
        {
            return Bl.VolunteeringCategoryBl.GetVolunteeringCategoryById(id);
        }

        [HttpPost]
        [Route("PostVolunteeringCategory")]
        public void Post(Dto.VolunteeringCategoryDto volunteeringCategoryDto)
        {
            Bl.VolunteeringCategoryBl.PostVolunteeringCategory(volunteeringCategoryDto);
        }

        [HttpPut]
        [Route("PutVolunteeringCategory")]
        public void Put(Dto.VolunteeringCategoryDto volunteeringCategoryDto)
        {
            Bl.VolunteeringCategoryBl.PutVolunteeringCategory(volunteeringCategoryDto);
        }

        [Route("DeleteVolunteeringCategory/{id}")]
        public void Delete(int id)
        {
            Bl.VolunteeringCategoryBl.DeleteVolunteeringCategory(id);
        }
    }
}
