using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("[controller]/[action]/{id}")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IMyFunc<User> uf;

        public UserController(IMyFunc<User> _uf)
        {
            uf = _uf;
        }


        [HttpPost]
        public User Login([FromBody] User user)
        {
            
            return user;
        }

        [HttpGet]
        public void Get(int id)
        {
            User u = new User();
            u.user_id=1;
            u.user_code="fan";
            uf.Select(u);
        }

    }
}