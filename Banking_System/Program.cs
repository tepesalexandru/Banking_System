using Banking_System.Classes;
using Banking_System.Classes.Authentication;
using Banking_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    class Program
    {
        static void Login()
        {
            Console.WriteLine("            ***********************************************");
            Console.WriteLine("            * Welcome to the BEST* Banking System in 2020 * ");
            Console.WriteLine("            ***********************************************");

            IUser user = new Authentication().Authenticate();
            user.ShowMenu();

        }
        static void Main(string[] args)
        {
            Login();
            Console.ReadKey();
        }
    }
}
