﻿using Common.Results;
using Common.Transactions;
using Entities.Repositories;
using Rest.Models.Rewards;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Rest.Controllers
{
    public class RewardController : BaseController
    {
        private readonly ITransactionScopeProvider transactionScopeProvider;
        private readonly IRewardRepository rewardRepository;
        private readonly IRewardService rewardService;

        public RewardController(ITransactionScopeProvider transactionScopeProvider, IRewardRepository rewardRepository,
            IRewardService rewardService )
        {
            this.transactionScopeProvider = transactionScopeProvider;
            this.rewardRepository = rewardRepository;
            this.rewardService = rewardService;
        }

        [Authorize]
        [Route("Api/Reward/Create")]
        public void CreateReward(RewardViewModel vm)
        {
            var user = GetCurrentUser();
            rewardService.CreateReward(user.Id, vm.Name, vm.Description, vm.Cost);
        }

        [Authorize]
        public RewardViewModel Get(int rewardID)
        {
            var user = GetCurrentUser();
            var reward = rewardRepository.FirstOrDefault(r => r.UserID == user.Id && r.ID == rewardID);

            return new RewardViewModel()
            {
                Cost = reward.Cost,
                Description = reward.Description,
                Name = reward.Name,
                RewardID = reward.ID
            };
        }

        [Authorize]
        public List<BasicRewardViewModel> Get()
        {
            var user = GetCurrentUser();
            return rewardRepository.Where(r => r.UserID == user.Id)
                .Select(r => new BasicRewardViewModel()
                {
                    Cost = r.Cost,
                    Name = r.Name,
                    RewardID = r.ID
                }).ToList();
        }



        [HttpPost]
        [Authorize]
        [Route("Api/Reward/BuyReward")]
        public void BuyReward(int rewardID)
        {
            using (var trs = transactionScopeProvider.CreateTransactionScope())
            {
                var user = GetCurrentUser();
                var reward = rewardRepository.GetById(rewardID);

                var result = rewardService.CanBuyReward(reward, user);
                if (result.IsError)
                    result.ThrowHttpException(System.Net.HttpStatusCode.Conflict);

                rewardService.BuyReward(reward, user);
                trs.Complete();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Api/Reward/CanBuy")]
        public MethodResult CanBuy(int rewardID)
        {
            var user = GetCurrentUser();
            var reward = rewardRepository.GetById(rewardID);

            return rewardService.CanBuyReward(reward, user);
        }
    }
}