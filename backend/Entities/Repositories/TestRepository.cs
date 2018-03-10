using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class TestRepository : RepositoryBase<Test, SessionBornEntities>, ITestRepository
    {
        public TestRepository(SessionBornEntities context) : base(context)
        {
        }
    }
}
