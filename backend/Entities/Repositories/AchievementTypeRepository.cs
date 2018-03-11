using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class AchievementTypeRepository : RepositoryBase<AchievementType, SessionBornEntities>, IAchievementTypeRepository
    {
        public AchievementTypeRepository(SessionBornEntities context) : base(context)
        {
        }
    }
}
