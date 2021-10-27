using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/ActionCategory")]

    public class ActionCategoryController : ApiController
    {
        [HttpGet]
        [Route("GetAllActionCategorys")]

        public List<Dto.ActionCategoryDto> GetAllActionCategorys()
        {
            return Bl.ActionCategoryBl.GetAllActionCategorys();
        }

        [HttpGet]
        [Route("GetActionCategoryById/{id}")]

        public Dto.ActionCategoryDto GetActionCategoryById(int id)
        {
            return Bl.ActionCategoryBl.GetActionCategoryById(id);
        }

        [HttpGet]
        [Route("GetActionCategoryOfBuilding/{id_building}")]

        public List<Dto.ActionCategoryDto> GetActionCategoryOfBuilding(int id_building)
        {
            return Bl.ActionCategoryBl.GetActionCategoryOfBuilding(id_building);
        }


        [HttpPost]
        [Route("PostActionCategory")]
        public void Post([FromBody]Dto.ActionCategoryDto actionCategoryDto)
        {
            Bl.ActionCategoryBl.PostActionCategory(actionCategoryDto);
        }

        [HttpPut]
        [Route("PutActionCategory")]
        public void Put([FromBody]Dto.ActionCategoryDto actionCategoryDto)
        {
            Bl.ActionCategoryBl.PutActionCategory(actionCategoryDto);
        }

        [Route("DeleteActionCategory/{id}")]
        public void Delete(int id)
        {
            Bl.ActionCategoryBl.DeleteActionCategory(id);
        }
    }
}
