using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Classes
{
    static class Helpers
    {
        public static int ReadInt(string message)
        {
            Console.WriteLine(message);
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
                return input;
            } catch (Exception)
            {
                ReadInt(message);
                return 0;
            }
            
        }

        public static string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
