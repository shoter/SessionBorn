using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class QuizRepository : RepositoryBase<Quize, SessionBornEntities>, IQuizRepository
    {
        public QuizRepository(SessionBornEntities context) : base(context)
        {
        }
    }
}
