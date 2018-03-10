using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Sidebars
{
    public class SidebarViewModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "photoLink")]
        public string PhotoLink { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/Adam_West_as_Batman.jpg/800px-Adam_West_as_Batman.jpg";
        [JsonProperty(PropertyName = "lvl")]
        public int Lvl { get; set; }
        [JsonProperty(PropertyName = "exp")]
        public int Exp { get; set; }
        [JsonProperty(PropertyName = "nextExp")]
        public int NextLevelExperience { get; set; }
        [JsonProperty(PropertyName = "levelPercentage")]
        public double LevelPercentage => (double)Exp / (double)NextLevelExperience;
    }
}