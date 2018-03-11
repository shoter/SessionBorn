using Entities;
using Entities.Enums;
using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectSpecific.Initializers
{
    public class AchievementAddonsInitializer
    {
        public static void Init()
        {
            var entities = new SessionBornEntities();
            var achievemtTypeRepository = new AchievementTypeRepository(entities);

            foreach (var achievementType in achievemtTypeRepository.GetAll())
            {
                var description = ((AchievementTypeEnum)achievementType.ID).GetDescription();
                achievementType.Description = description;
            }

            achievemtTypeRepository.SaveChanges();

        }
    }
}
