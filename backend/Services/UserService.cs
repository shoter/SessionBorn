using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Common.EncoDeco;
using Entities.Repositories;
using Common.Results;
using ProjectSpecific.Users;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IEncoder passwordHasher = new SHA256();
        private readonly IUserInfoRepository userRepository;
        private readonly IQuestRepository questRepository;
        public UserService(IUserInfoRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnCompletingQuest(int questID, string userID)
        {
            UserInfo currentUser = userRepository.FirstOrDefault(x => x.UserID == userID);
            Quest quest = questRepository.FirstOrDefault(x => x.ID == questID);

            if (currentUser != null && quest != null)
            {
                currentUser.Experience = currentUser.Experience + quest.Points;
            }
        }
    }
}
