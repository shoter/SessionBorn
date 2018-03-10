using Common.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        User CreateUser(string username, string plainTextPassword);
        MethodResult CanCreateUser(string username, string plainTextPassword);
        
    }
}
