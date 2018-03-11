using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum AchievementTypeEnum
    {
        [Description("Awarded for creating first scenario")]
        FirstAttendedScenario = 1,
        [Description("Awarded for completing fully first quest")]
        FirstCompletedQuest = 2,
        [Description("Awarded for completing first quiz")]
        FirstCompletedQuiz = 3,
        [Description("Awarded for using first reward")]
        FirstReward = 4
    }

    public static class AchievementTypeEnumExtensions
    {
        public static string GetDescription(this AchievementTypeEnum achievementType)
        {
            var type = typeof(AchievementTypeEnum);
            var memInfo = type.GetMember(achievementType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
