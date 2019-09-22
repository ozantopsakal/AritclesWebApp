using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLArticles:IArticles
    {
        private readonly AppDbContext context;

        public SQLArticles(AppDbContext context)
        {
            this.context = context;
        }

        public Articles Add(Articles article)
        {
            context.Add(article);
            context.SaveChanges();
            return article;
        }

        public Articles Delete(int id)
        {
            Articles article = context.Articles.Find(id);
            if (true)
            {
                context.Articles.Remove(article);
                context.SaveChanges();
            }
            return article;
        }

        public IEnumerable<Articles> GetAllArticles()
        {
            return context.Articles;
        }

        public Articles GetArticle(int id)
        {
            return context.Articles.Find(id);
        }

        public Articles Update(Articles changedArticle)
        {
            var article = context.Articles.Attach(changedArticle);
            article.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return changedArticle;
        }
    }
}
