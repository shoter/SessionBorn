using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Users
{
    public class CreateUserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}