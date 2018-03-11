using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Repositories;
using Entities;
using Common.Results;
using Entities.Enums;
using Services.DTOs.Motorllas;
using Common.Transactions;

namespace Services
{
    public class QuestService : IQuestService
    {
        private readonly IQuestRepository questRepository;
        private readonly IMotorollaService motorollaService;
        private readonly ITransactionScopeProvider transactionScopeProvider;

        public QuestService(IQuestRepository questRepository, IMotorollaService motorollaService, ITransactionScopeProvider transactionScopeProvider)
        {
            this.questRepository = questRepository;
            this.motorollaService = motorollaService;
            this.transactionScopeProvider = transactionScopeProvider;
        }

        public void CreateMotorollaMarker(Quest quest)
        {
            var model = new MotorollaSimpleModel()
            {
                metaHeader = new MotorollaSimpleModelMetaHeader()
                {
                    metaTimeStamp = toStringDate(DateTime.Now),
                    metaEventTypeLabel = quest.Name
                },
                eventHeader = new MotorollaSimpleModelMainHeader()
                {
                    detailedDescription = quest.Description,
                    label = quest.Name,
                    id = $"mot-{quest.ID}",
                    icon = new MotorllaSimpleModelIcon() { url = "MsiIcon://" + getIconForQuest(quest) },
                    location = new MotorllaSimpleModelLocation()
                    {
                        latitude = (double)quest.Latitude.Value,
                        longitude = (double)quest.Longitude.Value
                    },
                    priority = "medium",
                    timeStamp = toStringDate(DateTime.Now),
                    expirationTimeStamp = toStringDate(quest.DueDate)
                }
                
            };

            motorollaService.DoRequest(model);
        }

        private static string toStringDate(DateTime time)
        {
            return String.Format("{0:yyyy-MM-ddTHH:mm:ss.fffZ}", time);
        }

        private static string getIconForQuest(Quest quest)
        {
            switch ((QuestTypeEnum)quest.QuestTypeID)
            {
                //  case QuestTypeEnum.Meeting:
                case QuestTypeEnum.Test:
                    return "ic_document";
                case QuestTypeEnum.Exam:
                    return "ic_warrant_high";
                case QuestTypeEnum.Meeting:
                    return "ic_generic";
                case QuestTypeEnum.Quiz:
                    return "ic_incident_pending";
            }
            throw new NotImplementedException();
        }


        public Quest CreateQuest(string name, string desc,
                                int questType, int scenarioID, System.DateTime dueDate,
                                int points, Nullable<decimal> latitude = null,
                                Nullable<decimal> longitude = null )

        {
            using(var trs = transactionScopeProvider.CreateTransactionScope())
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
                TryToDoMotorllaMarker(quest);
                trs.Complete();
                return quest;
            }

        }

        public void TryToDoMotorllaMarker(Quest quest)
        {
            if (quest.Latitude.HasValue && quest.Longitude.HasValue)
                CreateMotorollaMarker(quest);
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

        public MethodResult CanCompleteQuest(Quest quest, AspNetUser user)
        {
            if (quest.Scenario.UserID != user.Id)
                return new MethodResult("Quest does not belong to you!");

            return MethodResult.Success;
        }

        public void CompleteQuest(Quest quest, AspNetUser user)
        {
            if (quest.Completed == false)
            {
                user.UserInfo.Points += quest.Points;
                user.UserInfo.Experience += quest.Points;
            }
            quest.Completed = true;
            questRepository.SaveChanges();
        }

    }
    
}
