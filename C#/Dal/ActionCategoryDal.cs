using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ActionCategoryDal
    {
        public static List<Dal.Action_Category> GetAllActionCategorys()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action_Category.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Action_Category GetActionCategoryById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action_Category.Where(actionCategory => actionCategory.id_action_category == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Action_Category> GetActionCategoryOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Action_Category.Where(actionCategory => actionCategory.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutActionCategory(Action_Category action_Category)
        {
            try
            {
                var entity = GetActionCategoryById(action_Category.id_action_category);
                if (entity == null){
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(action_Category);
            }
            catch (Exception e)
            {

            }
        }


        public static void PostActionCategory(Action_Category action_Category)
        {
            try
            {
                ManangementEntitiesSingleton.Instance.Action_Category.Add(action_Category);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteActionCategory(int id)
        {
            try
            {
                Dal.Action_Category itemToRemove = ManangementEntitiesSingleton.Instance.Action_Category.Where(x => x.id_action_category == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Action_Category.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}
