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
            var quiz = new Quize()
            {
                Quest = quest,
                Name = title,
                Description = description,
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
    }
}
