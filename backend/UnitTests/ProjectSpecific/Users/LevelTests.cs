using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectSpecific.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ProjectSpecific.Users
{
    [TestClass]
    public class LevelTests
    {

        [TestMethod]
        public void CalculateLevelForExperience_FirstLevel_tests()
        {
            for (int i = 0; i <= 9; ++i)
                Assert.AreEqual(1, Level.CalculateLevelForExperience(i));
        }

        [TestMethod]
        public void CalculateLevelForExperience_SecondLevel_tests()
        {
            for (int i = 10; i <= 29; ++i)
                Assert.AreEqual(2, Level.CalculateLevelForExperience(i));
        }

        [TestMethod]
        public void CalculateLevelForExperience_ThirdLevel_tests()
        {
            for (int i = 30; i <= 69; ++i)
                Assert.AreEqual(3, Level.CalculateLevelForExperience(i));
        }

        [TestMethod]
        public void CalculateExperienceForLevel_FirstLevels_tests()
        {
            Assert.AreEqual(10, Level.CalculateExperienceForLevel(1));
            Assert.AreEqual(30, Level.CalculateExperienceForLevel(2));
            Assert.AreEqual(70, Level.CalculateExperienceForLevel(3));

        }
    }
}
