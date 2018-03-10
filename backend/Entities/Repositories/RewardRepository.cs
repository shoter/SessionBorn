using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class RewardRepository : RepositoryBase<Reward, SessionBornEntities>, IRewardRepository
    {
        public RewardRepository(SessionBornEntities context) : base(context)
        {
        }
    }
}
