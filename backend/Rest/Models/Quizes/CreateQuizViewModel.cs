using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class CreateQuizViewModel
    {
        public QuestAddModel Quest { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuizNewQuestion> Questions { get; set; }

    }
}