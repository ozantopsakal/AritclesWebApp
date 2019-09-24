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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticles articles;
        private readonly ILogger<ArticlesController> logger;
        private Results results = new Results();

        public ArticlesController(IArticles articles, ILogger<ArticlesController> logger)
        {
            this.articles = articles;
            this.logger = logger;
        }

        // GET: api/Articles
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results GetArticleList()
        {
            try
            {
                results.Result = articles.GetAllArticlesAndTags();
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

        // GET: api/Articles/5
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results GetAnArticle(int id)
        {
            try
            {
                results.Result = articles.GetArticleAndTags(id);
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

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results SearchInArticles(string word)
        {
            try
            {
                results.Result = articles.SearchArticles(word);
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

        // POST: api/Articles
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public Results AddAnArticle(Articles article)
        {
            try
            {
                results.Result = articles.Add(article);
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

        // PUT: api/Articles/5
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public Results UpdateAnArticle(Articles article)
        {
            try
            {
                results.Result = articles.Update(article);
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
        public Results DeleteAnArticle(int id)
        {
            try
            {
                results.Result = articles.Delete(id);
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

        [HttpPost]
        public Results AddTagToArticle(TagsArticles tagsArticles)
        {
            try
            {
                var response = articles.AddTagToArticle(tagsArticles.ArticlesId, tagsArticles.TagsId);
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
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public Results RemoveTagFromArticle(TagsArticles tagsArticles)
        {
            try
            {
                var response = articles.RemoveTagFromArticle(tagsArticles.ArticlesId, tagsArticles.TagsId);
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
