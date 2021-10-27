using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Action")]
    public class ActionController : ApiController
    {
        [HttpGet]
        [Route("GetAllActions")]
        public List <Dto.ActionDto> GetAllActions()
        {
            return Bl.ActionBl.GetAllActions();
        }

        [HttpGet]
        [Route("GetActionById/{id}")]
        public Dto.ActionDto GetActionById(int id)
        {
            return Bl.ActionBl.GetActionById(id);
        }

        [HttpGet]
        [Route("GetActionsOfBuilding/{id_building}")]
        public List<Dto.ActionDto> GetActionsOfBuilding(int id_building)
        {
            return Bl.ActionBl.GetActionsOfBuilding(id_building);
        }

        [HttpGet]
        [Route("GetActionsOfBuildingYear/{id_building}/{year}")]
        public List<Dto.ActionDto> GetActionsOfBuildingYear(int id_building, int year)
        {
            return Bl.ActionBl.GetActionsOfBuildingYear(id_building, year);
        }

        [HttpGet]
        [Route("GetActionsOfBuildingYearMonth/{id_building}/{year}/{month}")]
        public List<Dto.ActionDto> GetActionsOfBuildingYear(int id_building, int year,int month)
        {
            return Bl.ActionBl.GetActionsOfBuildingYearMonth(id_building, year,month);
        }

        [HttpPut]
        [Route("PutAction")]
        public void Put(Dto.ActionDto actionDto)
        {
            Bl.ActionBl.PutAction( actionDto);
        }

        [HttpPost]
        [Route("PostAction")]
        public void Post(Dto.ActionDto actionDto)
        {
            Bl.ActionBl.PostAction(actionDto);
        }

        

        [Route("DeleteAction/{id}")]
        public void Delete(int id)
        {
            Bl.ActionBl.DeleteAction(id);
        }
    }
}
