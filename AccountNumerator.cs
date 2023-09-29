using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm
{
    public class AccountNumerator : IEnumerator
    {
        List<Account> account;
        int position = -1;

        public AccountNumerator(List<Account> account)
        {
            this.account = account;
        }

        public object Current 
        {
            get
            {
                if(position == -1 || position >= account.Count)
                {
                    throw new ArgumentException();
                }
                return account[position].id + 1;
            } 
        }

        public bool MoveNext()
        {
            if(position < account.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void Reset()
        {
            position = -1;
        }
    }
}
