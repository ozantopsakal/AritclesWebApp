using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface ITags
    {
        Tags GetTag(int id);
        IEnumerable<Tags> GetAllTags();
        Tags Add(Tags tag);
        Tags Update(Tags changedTag);
        Tags Delete(int id);
    }
}
