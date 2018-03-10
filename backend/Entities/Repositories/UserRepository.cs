using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class UserRepository : RepositoryBase<AspNetUser, SessionBornEntities>, IUserRepository
    {
        public UserRepository(SessionBornEntities context) : base(context)
        {
        }

        public AspNetUser GetUser(string username)
        {
            return Single(u => u.UserName == username);
        }

        public bool Exists(string username)
        {
            return Any(u => u.UserName == username);
        }
    }
}
