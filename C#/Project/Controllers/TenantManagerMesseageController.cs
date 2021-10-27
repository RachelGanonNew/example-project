using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/TenantManagerMesseage")]
    public class TenantManagerMesseageController : ApiController
    {
        [HttpGet]
        [Route("GetAllTenantManagerMesseages")]
        public List<Dto.TenantManagerMesseageDto> GetAllTenantManagerMesseages()
        {
            return Bl.TenantManagerMesseageBl.GetAllTenantManagerMesseages();
        }

        [HttpGet]
        [Route("GetTenantManagerMesseagesOfBuilding/{id_building}")]
        public List<Dto.TenantManagerMesseageDto> GetTenantManagerMesseagesOfBuilding(int id_building)
        {
            return Bl.TenantManagerMesseageBl.GetTenantManagerMesseagesOfBuilding(id_building);
        }

        [HttpGet]
        [Route("GetTenantManagerMesseageById/{id}")]
        public Dto.TenantManagerMesseageDto GetTenantManagerMesseageById(int id)
        {
            return Bl.TenantManagerMesseageBl.GetTenantManagerMesseageById(id);
        }

        [HttpPost]
        [Route("PostTenantManagerMesseageById")]
        public void Post(Dto.TenantManagerMesseageDto tenantManagerMesseageDto)
        {
            Bl.TenantManagerMesseageBl.PostTenantManagerMesseage(tenantManagerMesseageDto);
        }

        [HttpPut]
        [Route("PutTenantManagerMesseageById")]
        public void Put(Dto.TenantManagerMesseageDto tenantManagerMesseageDto)
        {
            Bl.TenantManagerMesseageBl.PutTenantManagerMesseage(tenantManagerMesseageDto);
        }

        [HttpPost]
        [Route("DeleteTenantManagerMesseageById")]
        public void Delete(int id)
        {
            Bl.TenantManagerMesseageBl.DeleteTenantManagerMesseage(id);
        }
    }
}
