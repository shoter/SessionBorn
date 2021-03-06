﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Quizes
{
    public class QuizAnswerViewModel
    {
        [JsonProperty(PropertyName = "quizID")]
        public int QuizID { get; set; }
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }
    }
}