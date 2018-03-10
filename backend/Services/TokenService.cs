using Common.Randoms;
using Entities;
using Entities.Repositories;
using ProjectSpecific.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }
        public UserToken CreateToken(User user, bool rememberMe)
        {
            string tokenValue = RandomGenerator.GenerateString(64) + Guid.NewGuid().ToString();
            var token = new Token()
            {
                DueDate = CalculateDueDate(rememberMe),
                User = user,
                Value = tokenValue
            };
            tokenRepository.Add(token);
            tokenRepository.SaveChanges();
            return new UserToken(token.Value, token.DueDate);
        }

        public void DeleteOldTokens()
        {
            var oldTokens = tokenRepository.GetDueTokens();
            foreach (var token in oldTokens)
                tokenRepository.Remove(token);

            tokenRepository.SaveChanges();
        }

        public DateTime CalculateDueDate(bool rememberMe)
        {
            DateTime dueDate = DateTime.Now.AddHours(1);
            if (rememberMe)
                dueDate.AddDays(7);
            return dueDate;
        }

        public void DeleteOldTokenIfAble(User user)
        {
            var tokens = tokenRepository.GetOldTokens(user.ID);
           foreach(var token in tokens)
            {
                tokenRepository.Remove(token);
                tokenRepository.SaveChanges();
            }
        }

        public User GetLoggedUser(string tokenValue)
        {
            var token = tokenRepository.GetToken(tokenValue);
            if (token == null)
                return null;
            return token.User;
        }

        public void RenewToken(Token token)
        {
            token.DueDate = CalculateDueDate(token.RememberMe);
            tokenRepository.SaveChanges();
        }
    }
}
