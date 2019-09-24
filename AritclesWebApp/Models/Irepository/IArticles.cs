using AritclesWebApp.Models.Class;
using AritclesWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface IArticles
    {
        Articles GetArticle(int id);
        IEnumerable<Articles> GetAllArticles();
        Articles Add(Articles article);
        Articles Update(Articles changedArticle);
        Articles Delete(int id);
        IEnumerable<Articles> SearchArticles(string word);
        IEnumerable<ArticleTagParameters> GetAllArticlesAndTags();
        ArticleTagParameters GetArticleAndTags(int id);
        Articles AddTagToArticle(int articleid,int tagId);
        Articles RemoveTagFromArticle(int articleid, int tagId);
    }
}
