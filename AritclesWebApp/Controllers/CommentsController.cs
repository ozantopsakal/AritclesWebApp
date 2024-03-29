﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace AritclesWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComments comments;
        private readonly ILogger<CommentsController> logger;
        private Results results = new Results();

        public CommentsController(IComments comments, ILogger<CommentsController> logger)
        {
            this.comments = comments;
            this.logger = logger;
        }

        // GET: api/Comments
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results GetCommentList()
        {
            try
            {
                results.Result = comments.GetAllComments();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // GET: api/Comments/5
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results GetAComment(int id)
        {
            try
            {
                results.Result = comments.GetAComment(id);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // POST: api/Comments
        [AllowAnonymous]
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public Results AddAComment(Comments comment)
        {
            try
            {
                results.Result = comments.AddAComment(comment);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // PUT: api/Comments/5
        [AllowAnonymous]
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public Results UpdateAComment(Comments comment)
        {
            try
            {
                results.Result = comments.UpdateAComment(comment);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results DeleteAComment(int id)
        {
            try
            {
                var response = comments.DeleteAComment(id);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }
    }
}
