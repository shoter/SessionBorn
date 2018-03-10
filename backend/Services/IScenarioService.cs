using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IScenarioService
    {
        Scenario CreateScenario(string name, string desc, string userID);

    }
}
