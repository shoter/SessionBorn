using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Results;
using Entities;
using Entities.Repositories;
using Common.Transactions;
using Entities.Enums;

namespace Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository rewardRepository;
        private readonly ITransactionScopeProvider transactionScopeProvider;
        private readonly IAchievementService achievementService;
        public RewardService(IRewardRepository rewardRepository, ITransactionScopeProvider transactionScopeProvider, IAchievementService achievementService)
        {
            this.rewardRepository = rewardRepository;
            this.transactionScopeProvider = transactionScopeProvider;
            this.achievementService = achievementService;
        }
        public void BuyReward(Reward reward, AspNetUser user)
        {
            user.UserInfo.Points -= reward.Cost;
            achievementService.TryToGiveAchievement(user.Id, AchievementTypeEnum.FirstReward);
            rewardRepository.SaveChanges();
        }

        public MethodResult CanBuyReward(Reward reward, AspNetUser user)
        {
            if (user == null)
                return new MethodResult("User does not exist!");

            if (reward == null)
                return new MethodResult("Reward does not exist!");

            if (reward.UserID != user.Id)
                return new MethodResult("It is not your reward!");

            if (reward.Cost > user.UserInfo.Points)
                return new MethodResult("You do not have enough points!");

            return MethodResult.Success;
        }

        public void CreateReward(string userID, string name, string description, int cost)
        {
            var reward = new Reward()
            {
                UserID = userID,
                Cost = cost,
                Description = description,
                Name = name
            };

            rewardRepository.Add(reward);
            rewardRepository.SaveChanges();
        }

    }
}
