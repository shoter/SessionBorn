using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizAnswerViewModel
    {
        public int QuizID { get; set; }
        public List<QuizAnswerItemViewModel> Answers { get; set; }
    }
}