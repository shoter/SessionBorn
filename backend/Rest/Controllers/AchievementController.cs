using Entities.Enums;
using Entities.Repositories;
using Rest.Models.Achievements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Controllers
{
    public class AchievementController : BaseController
    {
        private readonly IAchievementRepository achievementRepository;
        public AchievementController(IAchievementRepository achievementRepository)
        {
            this.achievementRepository = achievementRepository;
        }
        public IEnumerable<AchievementViewModel> GetAchievements()
        {
            var user = GetCurrentUser();
            var achievements = achievementRepository.Where(a => a.UserID == user.Id).ToList();

            return achievements.Select(a => new AchievementViewModel()
            {
                AchievementTypeID = a.AchievementTypeID,
                AchievementName = ((AchievementTypeEnum)a.AchievementTypeID).ToString()
            });
        }
    }
}