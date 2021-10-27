using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Event")]
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("GetEventsOfBuilding/{id_building}")]
        public List<Dto.EventDto> GetEventsOfBuilding(int id_building)
        {
            return Bl.EventBl.GetEventsOfBuilding(id_building);
        }


        [HttpPost]
        [Route("PostEvent")]
        public void Post(Dto.EventDto EventDto)
        {
            Bl.EventBl.PostEvent(EventDto);
        }
    }
}
