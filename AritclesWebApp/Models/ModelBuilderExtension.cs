using AritclesWebApp.Models.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Active = true,
                    Bio = "",
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "admin@webarticles.com",
                    Id = 1,
                    Name = "Admin",
                    Password = "@dM!n123",
                    Photo = "",
                    UserName = "admin",
                    UserTypes = (int)UserTypes.SuperAdmin
                }
                );
        }
        public static void MatchArticlesTags(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagsArticles>().HasKey(x => new { x.TagsId, x.ArticlesId });
        }
    }
}
