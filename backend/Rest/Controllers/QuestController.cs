﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Entities.Repositories;
using Services;
using Rest.Models;
using Entities.Enums;
namespace Rest.Controllers
{
    public class QuestController : BaseController
    {
        private readonly IQuestRepository questRepository;
        private readonly IQuestService questService;

        public QuestController(QuestRepository questRepository, QuestService questService)
        {
            this.questRepository = questRepository;
            this.questService = questService;
        }
        [Route("api/Quest/{id}")]
        public QuestGetModels Get(int id)
        {
            Quest quest = questRepository.GetById(id);

            bool isquiz = false;

            if (quest.QuestType.ID == (int)QuestTypeEnum.Quiz)
            {
                isquiz = true;
            }

            return new QuestGetModels
            {
                id = quest.ID,
                name = quest.Name,
                scenarioId = quest.ScenarioID,
                type = quest.QuestType.Name,
                dueDate = quest.DueDate,
                doneDate = quest.DoneDate,
                Latitude = quest.Latitude,
                Longitude = quest.Longitude,
                isQuiz = isquiz,
                completed = quest.Completed,
                description = quest.Description,
                points = quest.Points

            };
        }

        [Route("api/Quest/add")]
        public void Post(QuestAddModel quest)
        {
            questService.CreateQuest(quest.name, quest.description, quest.type, quest.scenarioId,
                quest.dueDate, quest.points, quest.Latitude, quest.Longitude);
            
        }

        [Route("api/Scenario/{id}/Quests")]
        public IEnumerable<QuestGetModels> GetList(int id)
        {

            Quest quest = questRepository.GetById(id);


            yield return new QuestGetModels
            {
                id = quest.ID,
                name = quest.Name,
                scenarioId = quest.ScenarioID,
                type = quest.QuestType.Name,
                dueDate = quest.DueDate,
                doneDate = quest.DoneDate,
                Latitude = quest.Latitude,
                Longitude = quest.Longitude,
                completed = quest.Completed,
                description = quest.Description,
                points = quest.Points
            };
        }
    }
}
