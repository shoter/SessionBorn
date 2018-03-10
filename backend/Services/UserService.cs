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
        public UserService(IUserInfoRepository userRepository)
        {
            this.userRepository = userRepository;
        }

    }
}
