using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm
{
    public class AccountComparer : IComparer<Account>
    {
        public int Compare(Account? x, Account? y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentException();
            }
            return x.Sum - y.Sum;
        }
    }
}
