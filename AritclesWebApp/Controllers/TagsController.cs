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
    public class TagsController : ControllerBase
    {
        private readonly ITags tags;
        private Results results = new Results();

        public TagsController(ITags tags)
        {
            this.tags = tags;
        }

        // GET: api/Tags
        [HttpGet]
        public Results GetTagList()
        {
            try
            {
                results.Result = string.Join(", ", tags.GetAllTags());
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

        // GET: api/Tags/5
        [HttpGet]
        public Results GetATag(int id)
        {
            try
            {
                results.Result = tags.GetTag(id).ToString();
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

        // POST: api/Tags
        [HttpPost]
        public Results AddATag(Tags tag)
        {
            try
            {
                results.Result = tags.Add(tag).ToString();
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

        // PUT: api/Tags/5
        [HttpPost]
        public Results UpdateATag(Tags tag)
        {
            try
            {
                results.Result = tags.Update(tag).ToString();
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
        public Results DeleteATag(int id)
        {
            try
            {
                results.Result = tags.Delete(id).ToString();
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
