using Entities;
using ProjectSpecific.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITokenService
    {
        UserToken CreateToken(User user, bool rememberMe);
        void DeleteOldTokens();
        DateTime CalculateDueDate(bool rememberMe);

        void DeleteOldTokenIfAble(User user);
    }
}
