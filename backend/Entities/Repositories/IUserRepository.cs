using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username);
        bool Exists(string username);

    }
}
