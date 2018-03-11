using Entities;
using Entities.Enums;
using Entities.Repositories;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository quizRepository;
        private readonly IAchievementService achievementService;
        public QuizService(IQuizRepository quizRepository, IAchievementService achievementService)
        {
            this.quizRepository = quizRepository;
            this.achievementService = achievementService;
        }


        public Quize CreateQuiz(Quest quest, IEnumerable<QuizNewQuestion> questions)
        {
            quest.Points = questions.Count();
            var quiz = new Quize()
            {
                
                Quest = quest,
                QuizQuestions = questions.Select(q =>
                new QuizQuestion()
                {
                    CorrectAnswer = q.Answer,
                    AnswerB = q.OptionB,
                    AnswerC = q.OptionC,
                    AnswerD = q.OptionD,
                    Question = q.Question
                }).ToList()
            };

            quizRepository.Add(quiz);
            quizRepository.SaveChanges();

            return quiz;
        }

        public void AnswerQuiz(Quize quiz, int points)
        {
            quiz.CollectedPoints = points;
            quiz.Quest.Completed = true;
            quiz.Quest.DoneDate = DateTime.Now;
            achievementService.TryToGiveAchievement(quiz.Quest.Scenario.UserID, AchievementTypeEnum.FirstCompletedQuiz);
            if(quiz.CollectedPoints == quiz.Quest.Points)
                achievementService.TryToGiveAchievement(quiz.Quest.Scenario.UserID, AchievementTypeEnum.FirstCompletedQuest);
            var userInfo = quiz.Quest.Scenario.AspNetUser.UserInfo;
            userInfo.Points += points;
            userInfo.Experience += points;
            quizRepository.SaveChanges();
        }
    }
}
