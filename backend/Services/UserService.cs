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
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
        }

        public User CreateUser(string username, string plainTextPassword)
        {
            string hashedPassword = passwordHasher.Encode(plainTextPassword);
            var user = new User()
            {
                Password = hashedPassword,
                Username = username
            };

            userRepository.Add(user);
            userRepository.SaveChanges();

            return user;
        }

        public MethodResult CanLogin(string username, string plainTextPassword)
        {
            if (userRepository.Exists(username) == false)
                return new MethodResult("User does not exist!");

            var user = userRepository.GetUser(username);
            var hashedPassword = passwordHasher.Encode(plainTextPassword);
            if (user.Password != hashedPassword)
                return new MethodResult("Wrong password!");


            return MethodResult.Success;
        }

        public UserToken Login(string username, string plainTextPassword, bool rememberMe)
        {
            var user = userRepository.GetUser(username);

            tokenService.DeleteOldTokenIfAble(user);

            var token = tokenService.CreateToken(user, rememberMe);
            return token;
        }

        public MethodResult CanCreateUser(string username, string plainTextPassword)
        {
            if (userRepository.Exists(username))
                return new MethodResult("Username already taken!");

            return MethodResult.Success;
        }
    }
}
