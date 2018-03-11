using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IQuestService
    {
        Quest CreateQuest(string name, string desc, 
                                int questType, int scenarioID, System.DateTime dueDate,
                                int points, Nullable<decimal> latitude = null,
                                Nullable<decimal> longitude = null);
    }
}
