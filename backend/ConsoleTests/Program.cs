using Entities;
using Entities.Repositories;
using ProjectSpecific.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumatorInitializer.Init();


            var context = new SessionBornEntities();



           
            Console.ReadKey();
        }
    }
}
