using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Comment")]
    public class ComentController : ApiController
    {
        // GET: api/Coment
        [HttpGet]
        [Route("GetAllComments")]
        public List<Dto.CommentDto> GetAllComments()
        {
            return Bl.CommentBl.GetAllComments();
        }

        [HttpGet]
        [Route("GetCommentById/{id}")]
        public Dto.CommentDto GetCommentById(int id)
        {
            return Bl.CommentBl.GetCommentById(id);
        }


        [HttpGet]
        [Route("GetCommentsOfBuilding/{id_building}")]
        public List<Dto.CommentDto> GetCommentsOfBuilding(int id_building)
        {
            return Bl.CommentBl.GetCommentsOfBuilding(id_building);
        }

        [HttpGet]
        [Route("GetCommentsByIdTenant/{id_tenant}")]
        public List<Dto.CommentDto> GetCommentsByIdTenant(int id_tenant)
        {
            return Bl.CommentBl.GetCommentsByIdTenant(id_tenant);
        }

        [HttpPost]
        [Route("PostComment")]
        public void Post(Dto.CommentDto commentDto)
        {
            Bl.CommentBl.PostComment(commentDto);
        }

        [HttpPut]
        [Route("PutComment")]
        public void Put(Dto.CommentDto commentDto)
        {
            Bl.CommentBl.PutComment(commentDto);
        }

        [Route("DeleteComment/{id}")]
        public void Delete(int id)
        {
            Bl.CommentBl.DeleteComment(id);
        }
    }
}
