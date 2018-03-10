using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Repositories;

namespace Services
{
    class ScenarioServices : IScenarioService
    {
        private readonly IScenarioRepository scenarioRepository;
        public ScenarioServices(IScenarioRepository scenarioRepository)
        {
            this.scenarioRepository = scenarioRepository;
        }
        public Scenario CreateScenario(string name, string desc, int userID)
        {
            var scenario = new Scenario
            {
                Name = name,
                Description = desc,
                UserID = userID
            };

            scenarioRepository.Add(scenario);
            scenarioRepository.SaveChanges();
            return scenario;

        }

    }
}
