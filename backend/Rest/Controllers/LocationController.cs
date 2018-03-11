using Entities;
using Entities.Repositories;
using Rest.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Controllers
{
    public class LocationController : BaseController
    {
        private readonly IQuestRepository questRepository;
        public LocationController(IQuestRepository questRepository)
        {
            this.questRepository = questRepository;
        }

        public IEnumerable<LocationViewModel> Get()
        {
            return selectLocations(questRepository.Query).ToList();
        }

        public IEnumerable<LocationViewModel> Get(bool completionFilter)
        {
            return selectLocations(questRepository.Query).Where(q => q.Completed == completionFilter).ToList();
        }


        /// <param name="dueFilter">If true then due quests are not displayed</param>
        /// <param name="completionFilter"></param>
        /// <returns></returns>
        public IEnumerable<LocationViewModel> Get(bool dueFilter, bool completionFilter = false)
        {
            var now = DateTime.Now;
            var query = selectLocations(questRepository.Query).Where(q => q.Completed == completionFilter);
            if (dueFilter)
                query = query.Where(q => now <= q.DueDate);
            return query.ToList();
        }

        private IQueryable<LocationViewModel> selectLocations(IQueryable<Quest> query)
        {
            return query
                .Where(q => q.Latitude.HasValue && q.Longitude.HasValue)
                            .Select(q => new LocationViewModel()
                            {
                                Completed = q.Completed,
                                DueDate = q.DueDate,
                                Latitude = (double)q.Latitude,
                                Longitude = (double)q.Longitude,
                                QuestID = q.ID,
                                QuestTitle = q.Name,
                                ScenarioID = q.Scenario.ID,
                                ScenarioTitle = q.Scenario.Name,
                                QuestTypeID = q.QuestTypeID
                            });
        }
    }
}