using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities.Repositories;
using Entities;
using Rest.Models;
using Services;

namespace Rest.Controllers
{


    public class ScenarioController : BaseController
    {
        private readonly IScenarioRepository scenarioRepository;
        private readonly ScenarioServices scenarioServices;
  
        public ScenarioController(ScenarioRepository scenarioRepository, ScenarioServices scenarioServices)
        {
            this.scenarioRepository = scenarioRepository;
            this.scenarioServices = scenarioServices;
        }


        public ScenarioGetModel Get(int id)
        {

            Scenario scenario = scenarioRepository.GetById(id);
            return new ScenarioGetModel
            {
                id = scenario.ID,
                scenarioName = scenario.Name,
                scenarioDesc = scenario.Description,
                userId = scenario.UserID,
                completed = scenarioServices.isCompleted(id),
                percentDone = scenarioServices.CalculateCompletion(id)

            };
        }

        [Authorize]
        public IEnumerable<ScenarioGetModel> GetList()
        {
            var user = GetCurrentUser();

            return scenarioRepository.GetUsersScenarios(user.Id).Select(scenario =>
                new ScenarioGetModel()
                {
                    id = scenario.ID,
                    scenarioName = scenario.Name,
                    scenarioDesc = scenario.Description,
                    userId = scenario.UserID,
                    completed = scenarioServices.isCompleted(scenario.ID),
                    percentDone = scenarioServices.CalculateCompletion(scenario.ID)
                });
          
        }

        [Authorize]
        [Route("api/Scenario/add")]
        public void Post(ScenarioAddModel scenario)
        {
            var user = GetCurrentUser();

            scenarioServices.CreateScenario(scenario.scenarioName, scenario.scenarioDesc, user.Id);
        }


    }
}
