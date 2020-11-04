using Banking_System.Enums;
using Banking_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banking_System.Classes.Accounts
{
    class Account : IAccount
    {
        public string name { get; set; }
        private float amount { get; set; }
        public AccountType type { get; }
        public Currency currency { get; }

        public List<Transaction> history = new List<Transaction>();
        public Account(AccountType type, Currency currency, string name)
        {
            this.type = type;
            this.name = name;
            this.currency = currency;
        }
        private void CreateTransaction(TransactionType type, float amount)
        {
            Transaction newTransaction = new Transaction(type, amount.ToString() + " " + this.currency);
            history.Add(newTransaction);
        }
        private void CreateTransaction(TransactionType type, string firstMessage, string secondMessage)
        {
            Transaction newTransaction = new Transaction(type, firstMessage, secondMessage);
            history.Add(newTransaction);
        }
        public float GetAmount()
        {
            return amount;
        }
        public void EditName(string name)
        {
            Console.WriteLine($"You have successfully changed the name of the account to '{name}'");
            CreateTransaction(TransactionType.Edit, this.name, name);
            this.name = name;
            
        }
        public void Deposit(float amount)
        {
            Console.WriteLine($"You have successfully deposited {amount} {currency}");
            this.amount += amount;
            CreateTransaction(TransactionType.Deposit, amount);
        }

        public bool Withdraw(float amount)
        {
            if (this.amount < amount)
            {
                Console.WriteLine($"You do not have enough money to withdraw {amount} {type}");
                return false;
            } else
            {
                this.amount -= amount;
                CreateTransaction(TransactionType.Withdraw, amount);
                return true;
            }
        }
        public void SaveTransactionHistory(string user)
        {
            string filePath = $@"C:\Users\Alex\source\repos\Banking_System\Banking_System\Database\Users\{user}\{name}.txt";
            using (var sr = new StreamWriter(filePath, false))
            {
                foreach (var trans in history)
                {
                    sr.WriteLine(trans.type.ToString().ToUpper() + " " + trans.message);
                }
            }
            Console.WriteLine($"Your transaction history for '{name}' has been successfully downloaded.");
        }
    }
}
