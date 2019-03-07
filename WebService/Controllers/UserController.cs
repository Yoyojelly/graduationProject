using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        [HttpPost]
        public User Login([FromBody] User user)
        {
            return user;
        }
    }
}