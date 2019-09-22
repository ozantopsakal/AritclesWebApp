using AritclesWebApp.Models.Class;
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
    }
}
