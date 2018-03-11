using Newtonsoft.Json;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class CreateQuizViewModel
    {
        [JsonProperty(PropertyName = "quest")]
        public QuestAddModel Quest { get; set; }
        [JsonProperty(PropertyName = "dueDate")]
        public DateTime DueDate { get; set; }
        [JsonProperty(PropertyName = "questions")]
        public List<QuizNewQuestion> Questions { get; set; }

    }
}