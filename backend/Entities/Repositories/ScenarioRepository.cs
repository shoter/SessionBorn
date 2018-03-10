using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.EntityFramework;

namespace Entities.Repositories
{
    public class ScenarioRepository : RepositoryBase<Scenario, SessionBornEntities>, IScenarioRepository
    {
        public ScenarioRepository(SessionBornEntities context) : base(context)
        {
        }

        public Scenario GetScenario(int scenarioID)
        {
            return SingleOrDefault(x => x.ID == scenarioID);
        }

        public List<Scenario> GetUsersScenarios(int userID)
        {
            return Where(x => x.UserID == userID).ToList();
        }
    }
}
