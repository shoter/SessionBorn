using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class TokenRepository : RepositoryBase<Token, SessionBornEntities>, ITokenRepository
    {
        public TokenRepository(SessionBornEntities context) : base(context)
        {
        }

        public List<Token> GetDueTokens()
        {
            var now = DateTime.Now;
            return Where(t => now > t.DueDate).ToList();
        }

        public Token GetToken(int userID)
        {
            return SingleOrDefault(t => t.UserID == userID);
        }

        public Token GetToken(string tokenValue)
        {
            return SingleOrDefault(t => t.Value == tokenValue);
        }
    }
}
