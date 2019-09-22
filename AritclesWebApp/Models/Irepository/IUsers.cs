using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface IUsers
    {
        Users GetUser(int id);
        IEnumerable<Users> GetAllUsers();
        Users Add(Users user);
        Users Update(Users changedUser);
        Users Delete(int id);
        Users Authenticate(string userName, string password);
    }
}
