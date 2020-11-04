using Banking_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Banking_System.Classes.Accounts;

namespace Banking_System.Classes.Users
{
    class Administrator : User, IUser
    {
        string path = @"C:\Users\Alex\source\repos\Banking_System\Banking_System\Database\Users";
        public void ShowUsers()
        {
            var myDir = Directory.GetFiles(path);
            int i = 1;
            Console.WriteLine("The following users use your bank: ");
            foreach(var file in myDir)
            {
                string[] s = file.ToString().Split('\\');
                string[] name = s[s.Length - 1].Split('.');


                Console.WriteLine(i + ". " + name[0]);
                i++;
            }
            if (i == 1)
            {
                Console.WriteLine("No one is using your bank system :(");
            }
        }
        public void ClearDatabase()
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Console.WriteLine("Your database has been deleted. Hope your users don't get mad!");
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the administrator panel.");
            Console.WriteLine("1. Show all users");
            Console.WriteLine("2. Clear the database");
            Console.WriteLine("Any other input will close the application\n");

            int input = Helpers.ReadInt("Select your option: ");
            Console.Clear();

            switch (input)
            {
                case 1:
                    ShowUsers();
                    break;
                case 2:
                    ClearDatabase();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            ShowMenu();

        }
    }
}
