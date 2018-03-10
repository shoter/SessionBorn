﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IQuestService
    {
        Quest CreateQuest(string name, string desc, bool completed,
                               int questType, int scenarioID, System.DateTime dueDate,
                               System.DateTime doneDate, Nullable<decimal> latitude,
                               Nullable<decimal> longitude, int points);
    }
}