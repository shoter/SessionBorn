using Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IQuizService
    {
        Quize CreateQuiz(Quest quest, IEnumerable<QuizNewQuestion> questions);
        void AnswerQuiz(Quize quiz, int points);
    }
}
