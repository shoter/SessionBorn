using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizAnswerItemViewModel
    {
        public int QuestionID { get; set; }
        public bool IsCorrect { get; set; }
    }
}