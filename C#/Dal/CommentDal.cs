using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CommentDal
    {
        public static List<Dal.Comment> GetAllComment()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Comment.ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Comment> GetCommentsOfBuilding(int id_building)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Comment.Where(comment => comment.id_building == id_building).ToList();
            }
            catch{
                return null;
            }
        }

        public static Dal.Comment GetCommentById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Comment.Where(comment => comment.id_comment == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static List  <Dal.Comment> GetCommentsByIdTenant(int id_tenant)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Comment.Where(comment => comment.id_tenant == id_tenant).ToList();
            }
            catch{
                return null;
            }
        }

        public static void PutComment(Comment comment)
        {
            try
            {
                var entity = GetCommentById(comment.id_comment);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(comment);
            }
            catch (Exception e)
            {

            }
        }

        public static void PostComment(Comment comment)
        {
            try{
                ManangementEntitiesSingleton.Instance.Comment.Add(comment);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteComment(int id)
        {
            try{
                Dal.Comment itemToRemove = ManangementEntitiesSingleton.Instance.Comment.Where(x => x.id_comment == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Comment.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }
}
