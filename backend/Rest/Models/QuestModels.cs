using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models
{
    public class QuestGetModels
    {
        public int id { get; set; }
        public string name { get; set; }
        public int scenarioId { get; set; }
        public string type { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime doneDate { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Boolean completed { get; set; }
        public string description { get; set; }
        public int points { get; set; }

    }

    public class QuestAddModel
    {

        public string name { get; set; }
        public int scenarioId { get; set; }
        public int type { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime doneDate { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Boolean completed { get; set; }
        public string description { get; set; }
        public int points { get; set; }

    }
}