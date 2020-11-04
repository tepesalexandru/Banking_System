using Banking_System.Enums;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Classes.Accounts
{
    class AccountCollection
    {
        List<Account> accounts = new List<Account>();

        public int Count()
        {
            return accounts.Count;
        }

        public Account GetAccount(int index)
        {
            return accounts[index];
        }

        public void NewAccount(AccountType accountType, Currency currency, string name)
        {
            Account newAccount = new Account(accountType, currency, name);
            accounts.Add(newAccount);
        }

        public void RemoveAccount(int index)
        {
            Console.WriteLine($"You have successfully deleted the account.");
            accounts.RemoveAt(index);
        }
    }
}
