using Common.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRewardService
    {
        MethodResult CanBuyReward(Reward reward, AspNetUser user);
        void BuyReward(Reward reward, AspNetUser user);
        void CreateReward(string userID, string name, string description, int cost);
    }
}
