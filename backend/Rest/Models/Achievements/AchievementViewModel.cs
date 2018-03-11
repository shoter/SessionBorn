using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Achievements
{
    public class AchievementViewModel
    {
        [JsonProperty(PropertyName = "achievementTypeID")]
        public int AchievementTypeID { get; set; }
        [JsonProperty(PropertyName = "achievementName")]
        public string AchievementName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}