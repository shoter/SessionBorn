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
        Quize CreateQuiz(Quest quest,string title, string description, IEnumerable<QuizNewQuestion> questions);
    }
}
