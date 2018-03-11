using Common.Transactions;
using Entities.Enums;
using Entities.Repositories;
using Rest.Models.Quizes;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Rest.Controllers
{
    public class QuizController : BaseController
    {
        private readonly IQuestService questService;
        private readonly IQuestRepository questRepository;
        private readonly IQuizService quizService;
        private readonly ITransactionScopeProvider transactionScopeProvider;
        private readonly IQuizRepository quizRepository;
        public QuizController(IQuestService questService, IQuizService quizService, ITransactionScopeProvider transactionScopeProvider,
            IQuestRepository questRepository, IQuizRepository quizRepository)
        {
            this.questService = questService;
            this.quizService = quizService;
            this.transactionScopeProvider = transactionScopeProvider;
            this.questRepository = questRepository;
            this.quizRepository = quizRepository;
        }

         [Route("Api/Quiz/Create")]
         [HttpPost]
         [Authorize]
         public void Create(CreateQuizViewModel vm)
         {
             using (var trs = transactionScopeProvider.CreateTransactionScope())
             {
                 var user = GetCurrentUser();
                var quest = questService.CreateQuest(
                    name: vm.Quest.name,
                    desc: vm.Quest.description,
                    dueDate: vm.Quest.dueDate,
                    latitude: vm.Quest.Latitude,
                    longitude: vm.Quest.Longitude,
                    points: 0, //will be calcualted
                    questType: (int)QuestTypeEnum.Quiz,
                    scenarioID: vm.Quest.scenarioId);

                var quiz = quizService.CreateQuiz(quest, vm.Questions);
                     
                 trs.Complete();
             }
         }

        [Authorize]
        public QuizViewModel Get(int quizID)
        {
            var quest = questRepository.Where(q => q.ID == quizID)
                 .Include(q => q.Quize).FirstOrDefault();
            var quiz = quest.Quize;
            var questions = quiz.QuizQuestions.ToList();

            return new QuizViewModel()
            {
                Description = quest.Description,
                Title = quest.Name,
                CollectedPoints = quest.Quize.CollectedPoints ?? 0,
                MaxPoints = quest.Points,
                Questions = questions.Select(q => 
                new QuizQuestionViewModel(q)).ToList()
            };
        }

        [Authorize]
        [Route("Api/Quiz/Answer")]
        [HttpPost]
        public void AnswerQuiz(QuizAnswerViewModel vm)
        {
            var quiz = quizRepository.GetById(vm.QuizID);
            quizService.AnswerQuiz(quiz, vm.Answers.Where(a => a.IsCorrect).Count());
        }
    }
}