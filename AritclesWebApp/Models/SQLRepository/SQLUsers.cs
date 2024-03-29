﻿using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.SQLRepository
{
    public class SQLUsers : IUsers
    {
        private readonly AppDbContext context;
        private readonly AppSettings _appSettings;

        public SQLUsers(AppDbContext context, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            _appSettings = appSettings.Value;
        }

        public Users Add(Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;

        }

        public Users Authenticate(string userName, string password)
        {
            Users user = context.Users.SingleOrDefault(x => x.Active && x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;
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

            context.SaveChanges();
            return changedUser;
        }
    }
}
