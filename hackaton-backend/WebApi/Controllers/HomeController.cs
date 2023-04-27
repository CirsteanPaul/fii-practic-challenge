using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    [Route("api/home")]
    public class HomeController : ApplicationController
    {
        // GET: /<controller>/
        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok(UserId);
        }
    }
}

