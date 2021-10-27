using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{        
    [RoutePrefix("api/Ad")]
    public class AdController : ApiController
    {
        //[HttpGet]
        //[Route("GetAllAds")]
        //public List<Dto.AdDto> Get()
        //{
        //    return Bl.AdBl.GetAllAds();
        //}

        //[HttpGet]
        //[Route("GetAdById/{id}")]
        //public Dto.AdDto GetAdById(int id)
        //{
        //    return Bl.AdBl.GetAdById(id);
        //}

        //[HttpGet]
        //[Route("GetAdsofBuilding/{id_building}")]
        //public List <Dto.AdDto> GetAdsofBuilding(int id_building)
        //{
        //    return Bl.AdBl.GetAdsOfBuilding(id_building);
        //}

        //[HttpPost]
        //[Route("PostAd")]
        //public void Post(Dto.AdDto adDto)
        //{
        //    Bl.AdBl.PostAd(adDto);
        //}

        //[HttpPut]
        //[Route("PutAd")]
        //public void Put( Dto.AdDto adDto)
        //{
        //    Bl.AdBl.PutAd(adDto);
        //}

        //[Route("DeleteAd/{id}")]
        //public void Delete(int id)
        //{
        //    Bl.AdBl.DeleteAd(id);
        //}
    }
}
