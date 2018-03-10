using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Repositories;

namespace Services
{
    public class ScenarioServices : IScenarioService
    {
        private readonly IScenarioRepository scenarioRepository;
        public ScenarioServices(IScenarioRepository scenarioRepository)
        {
            this.scenarioRepository = scenarioRepository;
        }
        public Scenario CreateScenario(string name, string desc, string userID)
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


        public void RemoveScenario(int scenarioID)
        {
            scenarioRepository.Remove(scenarioID);
            scenarioRepository.SaveChanges();
        }

        public void EditScenario(int scenarioID, string name, string desc, string userID)
        {
            Scenario scenarioToEdit = scenarioRepository.FirstOrDefault(x => x.ID == scenarioID);

            scenarioToEdit.Name = name;
            scenarioToEdit.Description = desc;
            scenarioToEdit.UserID = userID;

            scenarioRepository.SaveChanges();
        }

        public decimal CalculateCompletion(int scenarioID)
        {
            List<Quest> quests = scenarioRepository.FirstOrDefault(x => x.ID == scenarioID).Quests.ToList();
            decimal points = 0;
            decimal pointsGained = 0;
            foreach (Quest q in quests)
            {
                points = points + q.Points;
                if (q.Completed)
                {
                    pointsGained = pointsGained + q.Points;
                }
            }
            return (pointsGained / points)*100;
        }

        public bool isCompleted(int scenarioID)
        {
            List<Quest> quests = scenarioRepository.FirstOrDefault(x => x.ID == scenarioID).Quests.ToList();

            foreach (Quest q in quests)
            {
                if (!q.Completed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
