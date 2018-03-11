using Entities;
using Entities.Repositories;
using ProjectSpecific.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace ConsoleTests
{
    class Program
    {

        public static decimal NextDecimal( Random rnd, decimal from, decimal to)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(from).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(to).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
                scale = 28;

            decimal r = new decimal(rnd.Next(), rnd.Next(), rnd.Next(), false, scale);
            if (Math.Sign(from) == Math.Sign(to) || from == 0 || to == 0)
                return decimal.Remainder(r, to - from) + from;

            bool getFromNegativeRange = (double)from + rnd.NextDouble() * ((double)to - (double)from) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -from) + from : decimal.Remainder(r, to);
        }

        static void Main(string[] args)
        {
            /* ISce
             for (int i = 0; i < 10; ++i)
             {
                 string scenario = $"Super uber scenario {i}";
                 for (int j = 0; j < 50 ; ++j)
                 {
                     string quest = $"Rescure world {j}";

                 }
             }

            */
            SessionBornEntities context = new SessionBornEntities();
            MotorollaService motorolla = new MotorollaService();
            Common.Transactions.StandardTransactionScopeProvider scopeProvider = new Common.Transactions.StandardTransactionScopeProvider();
            ScenarioRepository scenarioRepo = new ScenarioRepository(context);
            QuestRepository questRepo = new QuestRepository(context);
            QuestService questService = new QuestService(questRepo, motorolla, scopeProvider);
            
            IEnumerable<Quest> ciastko = questRepo.GetAll();
            IEnumerable<Scenario> ciacho = scenarioRepo.GetAll();


            Console.WriteLine("Scenarios:");
            foreach (Scenario s in ciacho)
            {
                Console.WriteLine($"{s.ID} : {s.Name}");
            }
            foreach (Quest q in ciastko)
            {
                if(q.ScenarioID != 1)
                Console.WriteLine($"{q.ID} : {q.Name} : {q.Description} + {q.ScenarioID}");
            }


            //Tuple<decimal, decimal> latlong = getPoints();
            //questService.CreateQuest("Kolokwium 1", "1sze Kolokwium z Unixów", 1, 2, new DateTime(2018, 01, 11), 300, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Kolokwium 2", "2gie Kolokwium z Unixów", 1, 2, new DateTime(2018, 03, 14), 300, latlong.Item1, latlong.Item2);
            //latlong = getPoints();
            //questService.CreateQuest("Wykład", "Wykład z Unixów", 3, 2, new DateTime(2018, 02, 14), 20, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Pytania", "Pytania z próbnego egzaminu z zeszłego roku", 1, 2, new DateTime(2018, 05, 14), 200);
            //latlong = getPoints();
            //questService.CreateQuest("Kolokwium 1", "Kolokwium z Liczb Zespolonych", 1, 3, new DateTime(2018, 2, 5), 300, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Kolokwium 2", "Kolokwium z Dekompozycji Jordana", 1, 3, new DateTime(2018, 3, 7), 300, latlong.Item1, latlong.Item2);
            //latlong = getPoints();
            //questService.CreateQuest("Wykład", "Wykład z Algebry", 3, 3, new DateTime(2018, 3, 14), 20, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Pytania", "Pytania zdobyte od starszej grupy", 1, 3, new DateTime(2018, 6, 14), 200);
            //latlong = getPoints();
            //questService.CreateQuest("Egzamin", "Ekstremalnie trudny egzamin z algebry", 2, 3, new DateTime(2018, 6, 15), 600);
            //latlong = getPoints();
            //questService.CreateQuest("Kolokwium 1", "Kolokwium z Szybkiej Transformaty Fouriera", 1, 5, new DateTime(2018, 4, 5), 300, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Kolokwium 2", "Kolokwium z Przestrzeni Hilberta", 1, 5, new DateTime(2018, 05, 7), 300, latlong.Item1, latlong.Item2);
            //latlong = getPoints();
            //questService.CreateQuest("Wykład", "Wykład z obowiązkową obecnością z Matematyki", 3, 3, new DateTime(2018, 05, 14), 100, latlong.Item1, latlong.Item2);
            //questService.CreateQuest("Pytania", "Pytania zdobyte od starszej grupy", 1, 5, new DateTime(2018, 05, 14), 200);
            //latlong = getPoints();
            //questService.CreateQuest("Egzamin", "Prosty egzamin z matematyki", 2, 5, new DateTime(2018, 05, 14), 600);




            Console.ReadKey();

            Tuple<decimal, decimal> getPoints()
            {
                decimal latmin = new decimal(50.030331);
                decimal latmax = new decimal(50.08103);
                decimal longimin = new decimal(19.831237);
                decimal longimax = new decimal(19.881936);
                Random rnd = new Random();
                decimal lati = NextDecimal(rnd, latmin, latmax);
                decimal longi = NextDecimal(rnd, longimin, longimax);

                return new Tuple<decimal, decimal>(lati, longi);

            }


        }




    }
}
