using Banking_System.Classes.Accounts;
using Banking_System.Enums;
using Banking_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banking_System.Classes
{
    class Client : User, IUser
    {
        AccountCollection accounts = new AccountCollection();
        string filePath;
        public Client()
        {
            this.name = Helpers.ReadString("Enter your name: ");
            filePath = $@"C:\Users\Alex\source\repos\Banking_System\Banking_System\Database\Users\{name}.txt";
            string directoryMenu = $@"C:\Users\Alex\source\repos\Banking_System\Banking_System\Database\Users\{name}";
            File.Create(filePath, 1024);
            Directory.CreateDirectory(directoryMenu);
        }
        
        public void ViewAccounts()
        {
            Console.Clear();
            if (accounts.Count() == 0)
            {
                Console.WriteLine("You currently don't have any accounts open.");
            } else
            {
                Console.WriteLine("Here is a list of your accounts: ");
                int len = accounts.Count();
                for (int i = 0; i < len; i++)
                {
                    Account account = accounts.GetAccount(i);
                    Console.WriteLine($"{i + 1}. [{account.type}] {account.name}");
                    Console.WriteLine($"Current balance: {account.GetAmount()} {account.currency}\n");
                }
            }
        }
        public int SelectAccount()
        {
            Console.Clear();
            ViewAccounts();
            if (accounts.Count() == 0)
            {
                return -1;
            }
            Console.WriteLine("\nSelect an account by index: ");
            dynamic input = int.Parse(Console.ReadLine());
            return input - 1;
        }
        public void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("What type do you want your account to be? ");
            dynamic values = Enum.GetValues(typeof(AccountType));
            int i = 1;
            foreach(var value in values)
            {
                Console.WriteLine($"{i}. {value}");
                i++;
            }

            dynamic input = int.Parse(Console.ReadLine());

            AccountType type = (AccountType)(input - 1);
            Console.WriteLine("What currency do you want your account to be? ");
            values = Enum.GetValues(typeof(Currency));
            i = 1;
            foreach (var value in values)
            {
                Console.WriteLine($"{i}. {value}");
                i++;
            }

            input = int.Parse(Console.ReadLine());
            Currency currency = (Currency)(input - 1);

            Console.WriteLine("Insert a name for your new account");
            input = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Here are your settings: ");
            Console.WriteLine($"Name: {input}");
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Currency: {currency}");

            Console.WriteLine("\nPress 1 to confirm, press 2 to cancel.");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choice == 1)
            {
                accounts.NewAccount(type, currency, input);
                Console.WriteLine("Your account has been successfully added.");
            } else
            {
                Console.WriteLine("Your request has been canceled.");
            }
            

        }
        public void RenameAccount()
        {
            int accountNumber = SelectAccount();
            string name = Helpers.ReadString("Insert a new name for the account: ");

            Account account = accounts.GetAccount(accountNumber);
            account.EditName(name);
        }
        public void DeleteAccount()
        {
            int accountNumber = SelectAccount();
            accounts.RemoveAccount(accountNumber);
        }
        public void Deposit()
        { 
            int accountNumber = SelectAccount();
            int amount = Helpers.ReadInt("\nInsert amount to deposit: ");

            Account account = accounts.GetAccount(accountNumber);
            account.Deposit(amount);
        }
        public void Withdraw()
        {
            int accountNumber = SelectAccount();
            int amount = Helpers.ReadInt("\nInsert amount to withdraw: ");

            Account account = accounts.GetAccount(accountNumber);
            account.Withdraw(amount);
        }
        public void Exchange()
        {
            int accountNumber = SelectAccount();
            int secondAccountNumber = Helpers.ReadInt("Select destination account by index: ");

            Account firstAccount = accounts.GetAccount(accountNumber);
            Account secondAccount = accounts.GetAccount(secondAccountNumber - 1);

            int amount = Helpers.ReadInt($"Insert amount in {firstAccount.currency}: ");

            if (firstAccount.Withdraw(amount))
            {
                float exchangedAmount = new Exchanger().Exchange(firstAccount.currency, secondAccount.currency, amount);
                secondAccount.Deposit(exchangedAmount);
            }
            

        }
        public void SeeHistory()
        {
            int accountNumber = SelectAccount();
            Account account = accounts.GetAccount(accountNumber);
            Console.Clear();
            Console.WriteLine($"Here is the transaction history for '{account.name}'\n");

            for (int i = 0; i < account.history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {account.history[i].type.ToString().ToUpper()}: {account.history[i].message}");
            }

        }
        public void SeeRates()
        {
            Exchanger exchanger = new Exchanger();
            exchanger.PrintRates();
        }
        public void DownloadHistory()
        {
            int accountNumber = SelectAccount();
            Account account = accounts.GetAccount(accountNumber);
            account.SaveTransactionHistory(this.name);
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome User, what type of action do you want to do?");
            Console.WriteLine("1. View my accounts");
            Console.WriteLine("2. Create an account");
            Console.WriteLine("3. Make a deposit");
            Console.WriteLine("4. Withdraw money");
            Console.WriteLine("5. Edit an account");
            Console.WriteLine("6. Delete an account");
            Console.WriteLine("7. Exchange currencies");
            Console.WriteLine("8. See your transaction history");
            Console.WriteLine("9. See exchange rates");
            Console.WriteLine("10. Download transaction history");
            Console.WriteLine("Any other input will close the application.");
            Console.WriteLine("All of your data will be deleted upon leaving.");

            int input = Helpers.ReadInt("\nSelect your option:" );

            switch (input)
            {
                case 1:
                    ViewAccounts();
                    break;
                case 2:
                    CreateAccount();
                    break;
                case 3:
                    Deposit();
                    break;
                case 4:
                    Withdraw();
                    break;
                case 5:
                    RenameAccount();
                    break;
                case 6:
                    DeleteAccount();
                    break;
                case 7:
                    Exchange();
                    break;
                case 8:
                    SeeHistory();
                    break;
                case 9:
                    SeeRates();
                    break;
                case 10:
                    DownloadHistory();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadKey();
            ShowMenu();
            
        }
    }
}
