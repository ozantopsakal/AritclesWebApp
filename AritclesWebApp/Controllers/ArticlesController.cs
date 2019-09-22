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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticles articles;
        private Results results = new Results();
        
        public ArticlesController(IArticles articles)
        {
            this.articles = articles;
        }

        // GET: api/Articles
        [HttpGet]
        public Results GetArticleList()
        {
            try
            {
                results.Result = string.Join(", ", articles.GetAllArticlesAndTags());
                results.Code = 0;
                results.ErrorMessage=string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // GET: api/Articles/5
        [HttpGet]
        public Results GetAnArticle(int id)
        {
            try
            {
                results.Result = articles.GetArticleAndTags(id).ToString();
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

        [HttpGet]
        public Results SearchInArticles(string word)
        {
            try
            {
                results.Result = articles.SearchArticles(word).ToString();
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

        // POST: api/Articles
        [HttpPost]
        public Results AddAnArticle(Articles article)
        {
            try
            {
                var response = articles.Add(article);
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

        // PUT: api/Articles/5
        [HttpPost]
        public Results UpdateAnArticle(Articles article)
        {
            try
            {
                var response = articles.Update(article);
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
        public void DeleteAnArticle(int id)
        {
            try
            {
                var response = articles.Delete(id);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
        }
    }
}
