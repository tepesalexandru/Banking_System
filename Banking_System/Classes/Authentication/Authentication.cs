using Banking_System.Classes.Users;
using Banking_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Classes.Authentication
{
    class Authentication : IAuthenticate
    {
        public IUser Authenticate()
        {
            Console.WriteLine("Select your type of user: ");

            Console.WriteLine("1. Client");
            Console.WriteLine("2. Administrator");

            int input = Helpers.ReadInt("Select your option: ");

            IUser user = null;
            switch (input)
            {
                case 1:
                    user = new Client();
                    break;
                case 2:
                    user = new Administrator();
                    break;
            }
            return user;
        }
    }
}
