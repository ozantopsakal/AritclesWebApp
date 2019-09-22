using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLCategories : ICategories
    {
        private readonly AppDbContext context;

        public SQLCategories(AppDbContext context)
        {
            this.context = context;
        }

        public Categories Add(Categories category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Categories Delete(int id)
        {
            Categories category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return context.Categories;
        }

        public Categories GetCategory(int id)
        {
            return context.Categories.Find(id);
        }

        public Categories Update(Categories changedCategory)
        {
            var category = context.Categories.Attach(changedCategory);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return changedCategory;
        }
    }
}
