using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface IPosts
    {
        Posts GetPost(int id);
        IEnumerable<Posts> GetAllPosts();
        Posts Add(Posts post);
        Posts Update(Posts changedPost);
        Posts Delete(int id);
    }
}
