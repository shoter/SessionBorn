using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    interface IScenarioService
    {
        Scenario CreateScenario(string name, string desc, int userID);

    }
}
