using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Interfaces
{
    interface IAccount
    {
        void Deposit(float amount);
        bool Withdraw(float amount);

    }
}
