using Entities.Repositories;
using Rest.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Rest.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly IQuestRepository questRepository;
        public StatisticsController(IQuestRepository questRepository)
        {
            this.questRepository = questRepository;
        }
        [Authorize]
        [Route("Api/Statistics/GetMonthCompletions")]
        public List<CompletedQuestsByMonthViewModel> GetMonthCompletions()
        {
            var user = GetCurrentUser();
            return questRepository.Where(q => q.Scenario.UserID == user.Id)
                .Where(q => q.DoneDate.HasValue)
                .GroupBy(q => q.DoneDate.Value.Month)
                .ToList()
                .Select(q => new CompletedQuestsByMonthViewModel()
                {
                    CompletionCount = q.Count(),
                    MonthNumber = q.Key,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(q.Key)
                })
                .OrderBy(q => q.MonthName)
                .ToList();

        }
    }
}