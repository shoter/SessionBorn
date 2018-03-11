using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizQuestionViewModel
    {
        [JsonProperty(PropertyName = " id")]
        public long ID { get; set; }
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        [JsonProperty(PropertyName = "answer")]
        public string Answer { get; set; }
        [JsonProperty(PropertyName = "variants")]
        public List<string> Variants { get; set; }

        public QuizQuestionViewModel() { }
        public QuizQuestionViewModel(QuizQuestion question)
        {
            ID = question.ID;
            Question = question.Question;
            Answer = question.CorrectAnswer;
            Variants = new List<string>()
            {
                question.AnswerB,
                question.AnswerC,
                question.AnswerD
            };
        }
    }
}