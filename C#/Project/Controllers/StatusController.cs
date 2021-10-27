using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Status")]
    public class StatusController : ApiController
    {
    [HttpGet]
    [Route("GetAllStatuses")]
        public List<Dto.StatusDto> GetAllStatuses()
        {
            return Bl.StatusBl.GetAllStatuses();
        }

        [HttpGet]
        [Route("GetStatusById/{id}")]
        public Dto.StatusDto GetStatuseById(int id)
        {
            return Bl.StatusBl.GetStatusById(id);
        }

        [HttpPost]
        [Route("PostStatus")]
        public void Post(Dto.StatusDto statusDto)
        {
                Bl.StatusBl.PostStatus(statusDto);
        }

        [HttpPut]
        [Route("PutStatus")]
        public void Put(Dto.StatusDto statusDto)
        {
            Bl.StatusBl.PutStatus(statusDto);
        }

        [Route("DeleteStatus/{id}")]
        public void Delete(int id)
        {
            Bl.StatusBl.DeleteStatus(id);
        }
    }
}
