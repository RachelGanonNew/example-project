using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AdDal
    {
        //public static List<Dal.Ad> GetAllAds()
        //{
        //    try{
        //        return ManangementEntitiesSingleton.Instance.Ads.ToList();
        //    }
        //    catch{
        //        return null;
        //    }
        //}
        
        //public static Dal.Ad GetAdById(int id)
        //{
        //    try{
        //        return ManangementEntitiesSingleton.Instance.Ads.Where(x => x.id_ad == id).ToList()[0];
        //    }
        //    catch{
        //        return null;
        //    }
        //}
        
        //public static List<Dal.Ad> GetAdsofBuilding(int id_building)
        //{
        //    try{
        //        return ManangementEntitiesSingleton.Instance.Ads.Where(x => x.id_building == id_building).ToList();
        //    }
        //    catch{
        //        return null;
        //    }
        //}

        //public static void PutAd( Ad ad)
        //{
        //    try {
        //        var entity = GetAdById(ad.id_ad);
        //        if (entity == null)
        //        {
        //            return;
        //        }

        //        ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(ad);
        //    }
        //    catch(Exception e){
                
        //    }
        //}
       
        //public static void PostAd(Ad ad)
        //{
        //    try{
        //        ManangementEntitiesSingleton.Instance.Ads.Add(ad);
        //        ManangementEntitiesSingleton.Instance.SaveChanges();
        //    }
        //    catch (Exception e){
        //        Console.WriteLine(e.Message);
        //    }
        //}
        
        //public static void DeleteAd(int id)
        //{
        //    try
        //    {
        //        Dal.Ad itemToRemove = ManangementEntitiesSingleton.Instance.Ads.Where(x => x.id_ad == id).ToList()[0];
        //        if (itemToRemove != null)
        //        {
        //            ManangementEntitiesSingleton.Instance.Ads.Remove(itemToRemove);
        //            ManangementEntitiesSingleton.Instance.SaveChanges();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    
    
    
    }
}
