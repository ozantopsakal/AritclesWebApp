using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.SQLRepository
{
    public class SQLPosts : IPosts
    {
        private readonly AppDbContext context;

        public SQLPosts(AppDbContext context)
        {
            this.context = context;
        }

        public Posts Add(Posts post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public Posts Delete(int id)
        {
            Posts post = context.Posts.Find(id);
            if (post != null)
            {
                context.Posts.Remove(post);
                context.SaveChanges();
            }
            return post;
        }

        public IEnumerable<Posts> GetAllPosts()
        {
            return context.Posts;
        }

        public Posts GetPost(int id)
        {
            return context.Posts.Find(id);
        }

        public Posts Update(Posts changedPost)
        {
            var post = context.Posts.Attach(changedPost);
            post.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return changedPost;
        }
    }
}
