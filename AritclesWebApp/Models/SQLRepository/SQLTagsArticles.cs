using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLTagsArticles : ITagsArticles
    {
        private readonly AppDbContext context;

        public SQLTagsArticles(AppDbContext context)
        {
            this.context = context;
        }

        public TagsArticles Add(TagsArticles tagsArticles)
        {
            context.TagsArticles.Add(tagsArticles);
            context.SaveChanges();

            return tagsArticles;
        }

        public TagsArticles Delete(int id)
        {
            TagsArticles tagsArticles = context.TagsArticles.Find(id);
            if (tagsArticles != null)
            {
                context.TagsArticles.Remove(tagsArticles);
                context.SaveChanges();
            }
            return tagsArticles;
        }

        public IEnumerable<TagsArticles> GetAllTagsArticles()
        {
            return context.TagsArticles;
        }

        public TagsArticles GetTagsArticles(int id)
        {
            return context.TagsArticles.Find(id);
        }

        public TagsArticles Update(TagsArticles changedTagsArticles)
        {
            var tagsArticles = context.TagsArticles.Attach(changedTagsArticles);
            tagsArticles.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return changedTagsArticles;
        }
    }
}
