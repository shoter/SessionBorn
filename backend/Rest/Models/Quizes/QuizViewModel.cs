using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "collectedPoints")]
        public int CollectedPoints { get; set; }
        [JsonProperty(PropertyName = "maxPoints")]
        public int MaxPoints { get; set; }
        [JsonProperty(PropertyName = "questions")]
        public List<QuizQuestionViewModel> Questions { get; set; }
    }
}