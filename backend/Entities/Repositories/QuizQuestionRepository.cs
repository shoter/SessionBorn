using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class QuizQuestionRepository : RepositoryBase<QuizQuestion, SessionBornEntities>, IQuizQuestionRepository
    {
        public QuizQuestionRepository(SessionBornEntities context) : base(context)
        {
        }
    }
}
