using AritclesWebApp.Models.Class;
using AritclesWebApp.TempClasses;
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
        Articles AddTagsToArticle(int articleid,int tagId);
        Articles RemoveTagsToArticle(int articleid, int tagId);
    }
}
