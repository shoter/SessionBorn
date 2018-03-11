using Common.EntityFramework;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface IAchievementRepository : IRepository<Achievement>
    {
        bool Exists(string userID, AchievementTypeEnum achievementType);
    }
}
