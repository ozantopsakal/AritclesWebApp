using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLTags : ITags
    {
        private readonly AppDbContext context;

        public SQLTags(AppDbContext context)
        {
             this.context= context;
        }

        public Tags Add(Tags tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public Tags Delete(int id)
        {
            Tags tag = context.Tags.Find(id);
            if (tag != null)
            {
                context.Remove(tag);
                context.SaveChanges();

            }
            return tag;
        }

        public IEnumerable<Tags> GetAllTags()
        {
            return context.Tags;
        }

        public Tags GetTag(int id)
        {
            return context.Tags.Find(id);
        }

        public Tags Update(Tags changedTag)
        {
            var tag = context.Tags.Attach(changedTag);
            tag.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            
            return changedTag;
        }
    }
}
