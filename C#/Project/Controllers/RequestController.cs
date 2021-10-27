using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Request")]

    public class RequestController : ApiController
    {
        [HttpGet]
        [Route("GetAllRequests")]
        public List<Dto.RequestDto> GetAllRequests()
        {
            return Bl.RequestBl.GetAllRequests();
        }

        [HttpGet]
        [Route("GetRequestById/{id}")]
        public List<Dto.RequestDto> GetRequestById(int id)
        {
            return Bl.RequestBl.GetAllRequests();
        }

        [HttpPost]
        [Route("PostRequest")]
        public void Post(Dto.RequestDto requestDto)
        {
            Bl.RequestBl.PostRequest(requestDto);
        }

        [HttpPut]
        [Route("PutRequest")]
        public void Put(Dto.RequestDto requestDto)
        {
            Bl.RequestBl.PutRequest(requestDto);
        }

        [Route("DeleteRequest/{id}")]
        public void Delete(int id)
        {
            Bl.RequestBl.DeleteTenant(id);
        }
    }
}
