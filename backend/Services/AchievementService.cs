using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
using Entities.Repositories;

namespace Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository achievementRepository;
        public AchievementService(IAchievementRepository achievementRepository)
        {
            this.achievementRepository = achievementRepository;
        }
        public void TryToGiveAchievement(string userID, AchievementTypeEnum achievementType)
        {
            if (achievementRepository.Exists(userID, achievementType))
                return;

            achievementRepository.Add(new Entities.Achievement()
            {
                UserID = userID,
                AchievementTypeID = (int)achievementType
            });
            achievementRepository.SaveChanges();
        }
    }
}
