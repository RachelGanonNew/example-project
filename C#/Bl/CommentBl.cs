using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class CommentBl
    {
        public static List<Dto.CommentDto> GetAllComments()
        {
            return Dto.Convert.CommentConvert.ConvertDalEntityToDto(
                Dal.CommentDal.GetAllComment());
        }

        public static Dto.CommentDto GetCommentById(int id)
        {
            return Dto.Convert.CommentConvert.ConvertDalEntityToDto(
                Dal.CommentDal.GetCommentById(id));
        }

        public static List<Dto.CommentDto> GetCommentsOfBuilding(int id_building)
        {
            return Dto.Convert.CommentConvert.ConvertDalEntityToDto(
                Dal.CommentDal.GetCommentsOfBuilding(id_building));
        }

        public static List <Dto.CommentDto> GetCommentsByIdTenant(int id_tenant)
        {
            return Dto.Convert.CommentConvert.ConvertDalEntityToDto(
                Dal.CommentDal.GetCommentsByIdTenant(id_tenant));
        }

        public static void PutComment(Dto.CommentDto commentDto)
        {
            Dal.CommentDal.PutComment(
                Dto.Convert.CommentConvert.ConvertDalDtoToEntity(commentDto));
        }

        public static void PostComment(Dto.CommentDto commentDto)
        {
            Dal.CommentDal.PostComment(
                Dto.Convert.CommentConvert.ConvertDalDtoToEntity(commentDto));
        }

        public static void DeleteComment(int id)
        {
            Dal.CommentDal.DeleteComment(id);
        }

    }
}
