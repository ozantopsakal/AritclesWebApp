using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface IComments
    {
        Comments GetComment(int id);
        IEnumerable<Comments> GetAllComments();
        Comments Add(Comments comment);
        Comments Update(Comments changedComment);
        Comments Delete(int id);
    }
}
