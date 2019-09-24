using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.SQLRepository
{
    public class SQLComments : IComments
    {
        private readonly AppDbContext context;

        public SQLComments(AppDbContext context)
        {
            this.context = context;
        }

        public Comments AddAComment(Comments comment)
        {
            if (context.Articles.AsNoTracking().FirstOrDefault(x=>x.Id==comment.ArticleId) != null)
            {
                context.Comments.Add(comment);
                context.SaveChanges();
                return comment;
            }
            else
            {
                throw new ArgumentException("Makale bulunamadı.");
            }
        }

        public Comments DeleteAComment(int id)
        {
            Comments comment = context.Comments.Find(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
            }
            return comment;
        }

        public IEnumerable<Comments> GetAllComments()
        {
            return context.Comments;
        }

        public Comments GetAComment(int id)
        {
            return context.Comments.Find(id);
        }

        public Comments UpdateAComment(Comments changedComment)
        {
            if (context.Comments.AsNoTracking().FirstOrDefault(x => x.Id == changedComment.Id) != null)
            {
                var comment = context.Comments.Attach(changedComment);
                comment.State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Yorum bulunamadı.");
            }

            return changedComment;
        }
    }
}
