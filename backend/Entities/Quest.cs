//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int QuestTypeID { get; set; }
        public int ScenarioID { get; set; }
        public System.DateTime DueDate { get; set; }
        public System.DateTime DoneDate { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public int Points { get; set; }
    
        public virtual QuestType QuestType { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
