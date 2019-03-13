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
        public User Get(uint id)
        {
            User user = new User();
            user.user_id=id;

            if(uf.SingleSelect(user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

    }
}