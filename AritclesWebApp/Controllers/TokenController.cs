using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AritclesWebApp.Models.Irepository;
using AritclesWebApp.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AritclesWebApp.Helpers;

namespace AritclesWebApp.Controllers
{
    [Route("auth")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsers users;
        Results results = new Results();

        public TokenController(IUsers users)
        {
            this.users = users;
        }
        // GET: api/Token
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Token/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Token
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Token/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost]
        [ResponseCache(Duration =30)]
        public Results Authenticate(SignIn signIn)
        {
            try
            {
                results.Result = users.Authenticate(signIn.username, signIn.password);
                results.Code = 0;
                results.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                results.Code = 1;
                results.ErrorMessage = ex.Message;
            }
            return results;
        }
    }
}
