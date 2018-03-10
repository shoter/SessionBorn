using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Repositories;
using Entities;

namespace Services
{
    class QuestService : IQuestService
    {
        private readonly IQuestRepository questRepository;

        public QuestService(IQuestRepository questRepository)
        {
            this.questRepository = questRepository;           
        }

        public Quest CreateQuest(string name, string desc, bool completed,
                                int questType, int scenarioID, System.DateTime dueDate,
                                System.DateTime doneDate, Nullable<decimal> latitude,
                                Nullable<decimal> longitude, int points )

        {
            var quest = new Quest()
            {
                Name = name,
                Description = desc,
                Completed = completed,
                QuestTypeID = questType,
                ScenarioID = scenarioID,
                DueDate = dueDate,
                DoneDate = doneDate,
                Latitude = latitude,
                Longitude = longitude,
                Points = points
            };

            questRepository.Add(quest);
            questRepository.SaveChanges();
            return quest;

        }
    }
    
}
