using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AritclesWebApp.Controllers
{
    [Route("[controller]/[action]")]
    [Route("[controller]")]
    [Route("~/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ActionResult<IEnumerable<string>> Index()
        {
            return new string[] { "1", "2", "3", "4" };
        }
    }
}