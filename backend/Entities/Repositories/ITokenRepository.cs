﻿using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        List<Token> GetDueTokens();
        List<Token> GetOldTokens(int userID);
        Token GetToken(string tokenValue);
    }
}
