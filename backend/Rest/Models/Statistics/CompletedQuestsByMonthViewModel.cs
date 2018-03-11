using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Statistics
{
    public class CompletedQuestsByMonthViewModel
    {
        [JsonProperty(PropertyName = "monthNumber")]
        public int MonthNumber { get; set; }
        [JsonProperty(PropertyName = "monthName")]
        public string MonthName { get; set; }
        [JsonProperty(PropertyName = "completionCount")]
        public int CompletionCount { get; set; }
    }
}