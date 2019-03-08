using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WebService.Models
{
    public class User
    {
        public string UserName {get;set;}
        public string UserPwd {get;set;}
    }

    public class UserFunc
    {
        private  string connectionString { get; }

        public UserFunc(IOptions<MySqlOptions> mySqlOptions)
        {
            connectionString = mySqlOptions.Value.DefaultConnection;
        }

    }
}