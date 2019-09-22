using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Models.TempClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AritclesWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComments comments;
        private Results results = new Results();

        public CommentsController(IComments comments)
        {
            this.comments = comments;
        }

        // GET: api/Comments
        [HttpGet]
        public Results GetCommentList()
        {
            try
            {
                results.Result = string.Join(", ", comments.GetAllComments());
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // GET: api/Comments/5
        [HttpGet]
        public Results GetAComment(int id)
        {
            try
            {
                results.Result = comments.GetComment(id).ToString();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // POST: api/Comments
        [HttpPost]
        public Results AddAComment(Comments comment)
        {
            try
            {
                results.Result = comments.Add(comment).ToString();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // PUT: api/Comments/5
        [HttpPost]
        public Results UpdateAComment(Comments comment)
        {
            try
            {
                results.Result = comments.Update(comment).ToString();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        public Results Delete(int id)
        {
            try
            {
                results.Result = comments.Delete(id).ToString();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }
    }
}
