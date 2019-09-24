using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AritclesWebApp.Models.Class;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Models.Helpers;
using AritclesWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace AritclesWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private Results results = new Results();
        private readonly IUsers users;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUsers users, IOptions<AppSettings> appSettings,ILogger<UsersController> logger)
        {
            this.users = users;
            this.logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Results GetAllUsers()
        {
            try
            {
                results.Result = users.GetAllUsers();
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // GET: api/Users/5
        [HttpGet]
        [ResponseCache(Duration =30)]
        public Results GetAUser(int id)
        {
            try
            {
                results.Result = users.GetUser(id);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // POST: api/Users
        [HttpPost]
        [ResponseCache(Duration =30)]
        public Results AddAUser(Users user)
        {
            try
            {
                results.Result = users.Add(user);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // PUT: api/Users/5
        [HttpPost]
        [ResponseCache(Duration =30)]
        public Results UpdateAUser(Users user)
        {
            try
            {
                results.Result = users.Update(user);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [ResponseCache(Duration =30)]
        public Results DeleteAUser(int id)
        {
            try
            {
                var response = users.Delete(id);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }
    }
}
