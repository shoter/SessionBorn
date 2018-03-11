using Entities;
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
        public QuizService(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }


        public Quize CreateQuiz(Quest quest, string title, string description, IEnumerable<QuizNewQuestion> questions)
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
            quizRepository.SaveChanges();
        }
    }
}
