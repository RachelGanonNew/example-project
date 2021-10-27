using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProfessonalCategoryDal
    {
        public static List<Dal.Professonal_Category> GetAllProfessonalCategorys()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal_Category.ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Professonal_Category GetProfessonalCategoryById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal_Category.Where(professonalCategory => professonalCategory.id_professonal_category == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Professonal_Category> GetProfessonalCategoryOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Professonal_Category.Where(professonalCategory => professonalCategory.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutProfessonalCategory(Professonal_Category professonal_Category)
        {
            try{
                var entity = GetProfessonalCategoryById(professonal_Category.id_professonal_category);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(professonal_Category);
            }
            catch (Exception e){

            }
        }


        public static void PostProfessonalCategory(Professonal_Category professonal_Category)
        {
            try{
                ManangementEntitiesSingleton.Instance.Professonal_Category.Add(professonal_Category);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteProfessonalCategory(int id)
        {
            try{
                Dal.Professonal_Category itemToRemove = ManangementEntitiesSingleton.Instance.Professonal_Category.Where(x => x.id_professonal_category == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Professonal_Category.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
