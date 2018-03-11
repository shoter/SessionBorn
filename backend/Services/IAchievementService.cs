using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAchievementService
    {
        void TryToGiveAchievement(string userID, AchievementTypeEnum achievementType);
    }
}
