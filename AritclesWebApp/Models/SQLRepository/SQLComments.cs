﻿using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLComments : IComments
    {
        private readonly AppDbContext context;

        public SQLComments(AppDbContext context)
        {
            this.context = context;
        }

        public Comments Add(Comments comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        public Comments Delete(int id)
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

        public Comments GetComment(int id)
        {
            return context.Comments.Find(id);
        }

        public Comments Update(Comments changedComment)
        {
            var comment = context.Comments.Attach(changedComment);
            comment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            
            return changedComment;
        }
    }
}
