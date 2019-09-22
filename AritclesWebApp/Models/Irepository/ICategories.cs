using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface ICategories
    {
        Categories GetCategory(int id);
        IEnumerable<Categories> GetAllCategories();
        Categories Add(Categories category);
        Categories Update(Categories changedCategory);
        Categories Delete(int id);
    }
}
