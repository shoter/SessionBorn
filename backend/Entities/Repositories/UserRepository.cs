using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class UserRepository : RepositoryBase<User, SessionBornEntities>, IUserRepository
    {
        public UserRepository(SessionBornEntities context) : base(context)
        {
        }

        public User GetUser(string username)
        {
            return Single(u => u.Username == username);
        }

        public bool Exists(string username)
        {
            return Any(u => u.Username == username);
        }
    }
}
