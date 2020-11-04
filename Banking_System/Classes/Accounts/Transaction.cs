using Banking_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Classes.Accounts
{
    class Transaction
    {
        public TransactionType type;
        public string message { get; set; }
        public Transaction(TransactionType type, string amount)
        {
            this.type = type;
            this.message = amount;
        }
        public Transaction(TransactionType type, string firstMessage, string secondMessage)
        {
            this.type = type;
            this.message = firstMessage + " " + secondMessage;
        }
    }
}
