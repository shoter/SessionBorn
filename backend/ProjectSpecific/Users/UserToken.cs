using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSpecific.Users
{
    public class UserToken
    {
        /// <summary>
        /// Value of token. User need to pass it to be authenticated
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Expiration date of token. After this date user is no longer authenticated
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        public UserToken(string value, DateTime expirationDate)
        {
            this.Value = value;
            this.ExpirationDate = expirationDate;
        }
    }
}
