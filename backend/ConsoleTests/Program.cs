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
            AchievementAddonsInitializer.Init();

            var context = new SessionBornEntities();

          //  var repo = new TestRepository(context);
               
          //  var dupa = repo.GetAll();

            //foreach (var d in dupa)
              //  Console.WriteLine($"{d.ID} - {d.Name}");

           
            Console.ReadKey();
        }
    }
}
