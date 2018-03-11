using Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Locations
{
    public class LocationViewModel
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "questTitle")]
        public string QuestTitle { get; set; }
        [JsonProperty(PropertyName = "questID")]
        public int QuestID { get; set; }
        [JsonProperty(PropertyName = "scenarioID")]
        public int ScenarioID { get; set; }
        [JsonProperty(PropertyName = "scenarioTitle")]
        public string ScenarioTitle { get; set; }
        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }
        [JsonProperty(PropertyName = "dueDate")]
        public DateTime DueDate { get; set; }
        [JsonProperty(PropertyName = "questTypeID")]
        public int QuestTypeID { get; set; }
        [JsonProperty(PropertyName = "questTypeName")]
        public string QuestTypeName => ((QuestTypeEnum)QuestTypeID).ToString();
    }
}