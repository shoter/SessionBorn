using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models
{
    public class ScenarioGetModel
    {
        public int id { get; set; }
        public string scenarioName { get; set; }
        public string scenarioDesc { get; set; }
        public string userId { get; set; }
        public bool completed { get; set; }
        public decimal percentDone { get; set; }
    }

    public class ScenarioAddModel
    {
        public string scenarioName { get; set; }
        public string scenarioDesc { get; set; }
    }
}