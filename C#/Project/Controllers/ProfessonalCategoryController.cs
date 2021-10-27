using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/ProfessonalCategory")]

    public class ProfessonalCategoryController : ApiController
    {
        [HttpGet]
        [Route("GetAllProfessonalCategorys")]
        public List<Dto.ProfessonalCategoryDto> GetAllProfessonalCategorys()
        {
            return Bl.ProfessonalCategoryBl.GetAllProfessonalCategorys();
        }

        [HttpGet]
        [Route("GetProfessonalCategoryById/{id}")]
        public Dto.ProfessonalCategoryDto GetProfessonalCategoryById(int id)
        {
            return Bl.ProfessonalCategoryBl.GetProfessonalCategoryById(id);
        }


        [HttpGet]
        [Route("GetProfessonalCategoryOfBuilding/{id_building}")]
        public List<Dto.ProfessonalCategoryDto> GetProfessonalCategoryOfBuilding(int id_building)
        {
            return Bl.ProfessonalCategoryBl.GetProfessonalCategoryOfBuilding(id_building);
        }

        [HttpPost]
        [Route("PostProfessonalCategory")]
        public void Post(Dto.ProfessonalCategoryDto professonalCategoryDto)
        {
            Bl.ProfessonalCategoryBl.PostProfessonalCategory(professonalCategoryDto);
        }

        [HttpPut]
        [Route("PutProfessonalCategory")]
        public void Put(Dto.ProfessonalCategoryDto professonalCategoryDto)
        {
            Bl.ProfessonalCategoryBl.PutProfessonalCategory(professonalCategoryDto);
        }

        [Route("DeleteProfessonalCategory/{id}")]
        public void Delete(int id)
        {
            Bl.ProfessonalCategoryBl.DeleteProfessonalCategory(id);
        }
    }
}
