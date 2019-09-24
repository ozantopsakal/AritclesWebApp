using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface IComments
    {
        Comments GetAComment(int id);
        IEnumerable<Comments> GetAllComments();
        Comments AddAComment(Comments comment);
        Comments UpdateAComment(Comments changedComment);
        Comments DeleteAComment(int id);
    }
}
