using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.TempClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLArticles : IArticles
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

        public Articles AddTagsToArticle(int articleid, int tagId)
        {
            Articles article = context.Articles.FirstOrDefault(x => x.Id == articleid);

            var ta = new TagsArticles
            {
                ArticlesId = article.Id,
                TagsId = tagId
            };
            var tag = context.TagsArticles.Add(ta);
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

        public IEnumerable<ArticleTagParameters> GetAllArticlesAndTags()
        {
            List<ArticleTagParameters> model = new List<ArticleTagParameters>();
            var articleList = context.Articles.ToList();
            if (articleList != null && articleList.Count > 0)
            {
                foreach (var item in articleList)
                {
                    ArticleTagParameters mItem = new ArticleTagParameters();
                    var tagList = (from tag in context.Tags
                                   join ta in context.TagsArticles.Where(o => o.ArticlesId == item.Id) on tag.Id equals ta.TagsId
                                   select new Tags
                                   {
                                       Id = tag.Id,
                                       Title = tag.Title
                                   }).ToList();

                    mItem.Active = item.Active;
                    mItem.AllowsComments = item.AllowsComments;
                    mItem.CategoryId = item.CategoryId;
                    mItem.Id = item.Id;
                    mItem.Language = item.Language;
                    mItem.Photo = item.Photo;
                    mItem.PostedAt = item.PostedAt;
                    mItem.SubTitle = item.SubTitle;
                    mItem.TagList = tagList;
                    mItem.Text = item.Text;
                    mItem.ThumbnailPhoto = item.ThumbnailPhoto;
                    mItem.Title = item.Title;
                    mItem.UserId = item.UserId;
                    model.Add(mItem);
                }
            }
            return model;
        }

        public Articles GetArticle(int id)
        {
            return context.Articles.Find(id);
        }

        public ArticleTagParameters GetArticleAndTags(int id)
        {
            ArticleTagParameters model = new ArticleTagParameters();
            var article = context.Articles.FirstOrDefault(x => x.Id == id);
            if (article != null)
            {
                var tagList = (from tag in context.Tags
                               join ta in context.TagsArticles.Where(o => o.ArticlesId == article.Id) on tag.Id equals ta.TagsId 
                               into Tags
                               select new Tags
                               {
                                   Id = tag.Id,
                                   Title = tag.Title
                               }).ToList();

                model.Active = article.Active;
                model.AllowsComments = article.AllowsComments;
                model.CategoryId = article.CategoryId;
                model.Id = article.Id;
                model.Language = article.Language;
                model.Photo = article.Photo;
                model.PostedAt = article.PostedAt;
                model.SubTitle = article.SubTitle;
                model.TagList = tagList;
                model.Text = article.Text;
                model.ThumbnailPhoto = article.ThumbnailPhoto;
                model.Title = article.Title;
                model.UserId = article.UserId;
            }
            return model;
        }

        public Articles RemoveTagsToArticle(int articleid, int tagId)
        {
            Articles article = context.Articles.FirstOrDefault(x => x.Id == articleid);

            var ta = new TagsArticles
            {
                ArticlesId = article.Id,
                TagsId = tagId
            };
            var tag = context.TagsArticles.Remove(ta);
            return article;
        }

        public IEnumerable<Articles> SearchArticles(string word)
        {
            return context.Articles.Where(x => x.Title.Contains(word));
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
