using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.EntityFramework;

namespace Entities.Repositories
{
    public interface IScenarioRepository : IRepository<Scenario>
    {
        List<Scenario> GetUsersScenarios(int userID);
        Scenario GetScenario(int scenarioID);

        
    }
}
