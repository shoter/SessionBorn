using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizListItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int QuizID { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "questions")]
        public int Questions { get; set; }
        public int Points { get; set; }
    }
}