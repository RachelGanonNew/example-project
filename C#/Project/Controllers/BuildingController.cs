using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project.Controllers
{
    [RoutePrefix("api/Building")]
    public class BuildingController : ApiController
    {
        [HttpGet]
        [Route("GetAllBuildings")]
        public List<Dto.BuildingDto> GetAllBuildings()
        {
            return Bl.BuildingBl.GetAllBuildings();
        }

        [HttpGet]
        [Route("GetBuildingById/{id}")]
        public Dto.BuildingDto GetBuildingById(int id)
        {
            return Bl.BuildingBl.GetBuildingById(id);
        }

        //[HttpGet]
        //[Route("GetBuildingByAddres/{city}/{street}/{street_num}")]
        //public Dto.BuildingDto GetBuildingByAddres(string city,string street, int street_num)
        //{
        //    return Bl.BuildingBl.GetBuildingByAddres(city, street, street_num);
        //}

        [HttpPost]
        [Route("GetBuildingByAddres")]
        public Dto.BuildingDto GetBuildingByAddres(Bl.Model.Address address)
        {
            return Bl.BuildingBl.GetBuildingByAddres(address.city, address.street, address.street_num);
        }
        [HttpGet]
        [Route("GetBuildingByIdBuilding/{id}")]
        public Dto.BuildingDto GetBuildingByIdBuilding(int idBuilding)
        {
            return Bl.BuildingBl.GetBuildingByIdBuilding(idBuilding);
        }



        //[HttpPost]
        //[Route("tryPost")]
        //public int TryPost(Dto.TryDto postTry)
        //{
        //    return 0;
        //}


        [HttpPost]
        [Route("PostBuilding")]
        public int Post(Dto.BuildingDto buildingDto)
        {
            return Bl.BuildingBl.PostBuilding(buildingDto);           
        }

        [HttpPut]
        [Route("PutBuilding")]
        public void Put(Dto.BuildingDto buildingDto)
        {
            Bl.BuildingBl.PutBuilding(buildingDto);
        }

        [Route("DeleteBuilding/{id}")]
        public void Delete(int id)
        {
            Bl.BuildingBl.DeleteBuilding(id);
        }
        
        [HttpPut]
        [Route("UpdateBuildingTenants/{idBuilding}/{idTenant}")]
        public void UpdateBuildingTenants(int idBuilding, int idTenant)
        {
            Bl.BuildingBl.UpdateBuildingTenants(idBuilding, idTenant);
        }
    }
}
