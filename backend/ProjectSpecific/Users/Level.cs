using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSpecific.Users
{
    public class Level
    {
        public int CurrentLevel => CalculateLevelForExperience(Experience);
        public int Experience { get; set; }
        public int ExperienceForNextLevel => CalculateExperienceForLevel(CurrentLevel);

        public Level(int experience)
        {
            Experience = experience;
        }

        public static int CalculateExperienceForLevel(int level)
        {
            int exp = 0;
            for (int i = 0; i < level; ++i)
            {
                exp += 10 + exp;
            }
            return exp;
        }

        public static int CalculateLevelForExperience(int exp)
        {
            int level = 0;
            while (CalculateExperienceForLevel(++level) <= exp)
            {}
            return level;
        }
    }
}
