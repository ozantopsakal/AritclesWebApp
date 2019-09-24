using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AritclesWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagsController : ControllerBase
    {
        private readonly ITags tags;
        private readonly ILogger<TagsController> logger;
        private Results results = new Results();

        public TagsController(ITags tags, ILogger<TagsController> logger)
        {
            this.tags = tags;
            this.logger = logger;
        }

        // GET: api/Tags
        [HttpGet]
        [ResponseCache(Duration =30)]
        public Results GetTagList()
        {
            try
            {
                results.Result = tags.GetAllTags();
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

        // GET: api/Tags/5
        [HttpGet]
        [ResponseCache(Duration =30)]
        public Results GetATag(int id)
        {
            try
            {
                results.Result = tags.GetTag(id);
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

        // POST: api/Tags
        [HttpPost]
        [ResponseCache(Duration =30)]
        public Results AddATag(Tags tag)
        {
            try
            {
                results.Result = tags.Add(tag);
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

        // PUT: api/Tags/5
        [HttpPost]
        [ResponseCache(Duration =30)]
        public Results UpdateATag(Tags tag)
        {
            try
            {
                results.Result = tags.Update(tag);
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
        [ResponseCache(Duration =30)]
        public Results DeleteATag(int id)
        {
            try
            {
                var response = tags.Delete(id);
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
