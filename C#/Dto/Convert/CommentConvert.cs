using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class CommentConvert
    {
        public static List<CommentDto> ConvertDalEntityToDto(List<Dal.Comment> comments)
        {
            if (comments == null)
                return null;
            List<CommentDto> CommentDtos = comments.Select(c => ConvertDalEntityToDto(c)).ToList();
            return CommentDtos;

        }

        public static CommentDto ConvertDalEntityToDto(Dal.Comment comment)
        {
            if (comment is null)
                return null;
            CommentDto commentDto = new CommentDto()
            {
                id_comment = comment.id_comment,
                id_meeting = comment.id_meeting,
                id_tenant = comment.id_tenant,
                comment_description = comment.comment_description,
                comment_date = comment.comment_date,
                id_building=comment.id_building
            };


            return commentDto;

        }


        public static Dal.Comment ConvertDalDtoToEntity(CommentDto commentDto)
        {
            try
            {
                Dal.Comment comment = new Dal.Comment()
                {
                    id_comment = commentDto.id_comment,
                    id_meeting = commentDto.id_meeting,
                    id_tenant = commentDto.id_tenant,
                    comment_description = commentDto.comment_description,
                    comment_date = commentDto.comment_date,
                    id_building= commentDto.id_building
                };
                return comment;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
