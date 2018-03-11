using Common.EntityFramework;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class AchievementRepository : RepositoryBase<Achievement, SessionBornEntities>, IAchievementRepository
    {
        public AchievementRepository(SessionBornEntities context) : base(context)
        {
        }

        public bool Exists(string userID, AchievementTypeEnum achievementType)
        {
            return Any(a => a.UserID == userID && a.AchievementTypeID == (int)achievementType);
        }
    }
}
