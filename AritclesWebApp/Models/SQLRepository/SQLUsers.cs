using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.MockRepository
{
    public class SQLUsers : IUsers
    {
        private readonly AppDbContext context;

        public SQLUsers(AppDbContext context)
        {
            this.context = context;
        }

        public Users Add(Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;

        }

        public Users Delete(int id)
        {
            Users user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return (user);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users;
        }

        public Users GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public Users Update(Users changedUser)
        {
            var user = context.Users.Attach(changedUser);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return changedUser;
        }
    }
}
