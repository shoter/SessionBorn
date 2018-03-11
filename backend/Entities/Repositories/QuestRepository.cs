using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.EntityFramework;

namespace Entities.Repositories
{
    public class QuestRepository : RepositoryBase<Quest, SessionBornEntities>, IQuestRepository
    {
        public QuestRepository(SessionBornEntities context) : base(context)
        {
        }

        public List<Quest> GetScenarioQuests(int scenarioID)
        {
            return Where(x => x.ScenarioID == scenarioID).ToList();
        }
        public Quest GetQuest(int questID)
        {
            return SingleOrDefault(x => x.ID == questID);
        }

        public List<Quest> GetQuestsForUserForDayMonth(int year, int month, List<Scenario> scenarios)
        {

            return Where(x => x.DueDate.Month == month && x.DueDate.Year == year && scenarios.Contains(x.Scenario)).ToList();
        }

     }
}
