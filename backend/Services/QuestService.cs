using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Repositories;
using Entities;

namespace Services
{
    public class QuestService : IQuestService
    {
        private readonly IQuestRepository questRepository;

        public QuestService(IQuestRepository questRepository)
        {
            this.questRepository = questRepository;           
        }

        public Quest CreateQuest(string name, string desc,
                                int questType, int scenarioID, System.DateTime dueDate,
                                int points, Nullable<decimal> latitude = null,
                                Nullable<decimal> longitude = null )

        {
            var quest = new Quest()
            {
                Name = name,
                Description = desc,
                Completed = false,
                QuestTypeID = questType,
                ScenarioID = scenarioID,
                DueDate = dueDate,
                Latitude = latitude,
                Longitude = longitude,
                Points = points
            };

            
            questRepository.Add(quest);
            questRepository.SaveChanges();
            return quest;

        }

        public void RemoveQuest(int questID)
        {
            questRepository.Remove(questID);
            questRepository.SaveChanges();
        }


        public void EditQuest(int questID, string name, string desc, bool completed,
                                int questType, int scenarioID, System.DateTime dueDate,
                                System.DateTime doneDate, int points, Nullable<decimal> latitude = null,
                                Nullable<decimal> longitude = null)
        {
            Quest questToEdit = questRepository.FirstOrDefault(x => x.ID == scenarioID);

            questToEdit.Name = name;
            questToEdit.Description = desc;
            questToEdit.Completed = completed;
            questToEdit.QuestTypeID = questType;
            questToEdit.ScenarioID = scenarioID;
            questToEdit.DueDate = dueDate;
            questToEdit.DoneDate = doneDate;
            questToEdit.Latitude = latitude;
            questToEdit.Longitude = longitude;
            questToEdit.Points = points;

            questRepository.SaveChanges();
      
        }




    }
    
}
