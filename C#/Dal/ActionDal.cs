using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ActionDal
    {
        public static List<Dal.Action> GetAllActions()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action.ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Action> GetActionsOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action.Where(action => action.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Action> GetActionsOfBuildingYear(int id_building,int year)
        {
            try{
                 
                return ManangementEntitiesSingleton.Instance.Action.Where(action => action.id_building == id_building && action.action_date.Value.Year == year).ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Action> GetActionsOfBuildingYearMonth(int id_building, int year, int month)
        {
            try{
                 return ManangementEntitiesSingleton.Instance.Action.Where(action => action.id_building == id_building &&
                action.action_date.Value.Year == year&&
                action.action_date.Value.Month == month).ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Action GetActionById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action.Where(action => action.id_action == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static void PutAction(Action action)
        {
            try
            {
                var entity = GetActionById(action.id_action);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(action);
            }
            catch (Exception e)
            {

            }
        }

        public static void PostAction(Action action)
        {
            try{
                ManangementEntitiesSingleton.Instance.Action.Add(action);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteAction(int id)
        {
            try{
                Dal.Action itemToRemove = ManangementEntitiesSingleton.Instance.Action.Where(x => x.id_action == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Action.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
