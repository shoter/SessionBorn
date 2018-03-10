using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}
