using Banking_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace Banking_System.Classes.Accounts
{
    class Exchanger
    {
        private Dictionary<Currency, float> rates = new Dictionary<Currency, float>();
        private string path = @"C:\Users\Alex\source\repos\Banking_System\Banking_System\Database\Rates.txt";
        public Exchanger()
        {
            Currency[] all = new Currency[3] { Currency.EUR, Currency.RON, Currency.USD };
            int i = 0;
            
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    float rate = float.Parse(s);
                    rates[all[i]] = rate;
                    i++;
                }
            }
        }
        public float Exchange(Currency from, Currency to, int amount)
        {
            float inEuro = rates[from] * amount;
            float toOther = inEuro * (1 / rates[to]);
            return toOther;
        }

        public void PrintRates()
        {
            Console.Clear();
            Console.WriteLine("Current rates: ");
            Console.WriteLine($"1 EUR -> {Exchange(Currency.EUR, Currency.RON, 1)} RON");
            Console.WriteLine($"1 EUR -> {Exchange(Currency.EUR, Currency.USD, 1)} USD");
            Console.WriteLine($"1 RON-> {Exchange(Currency.RON, Currency.EUR, 1)} EUR");
            Console.WriteLine($"1 RON -> {Exchange(Currency.RON, Currency.USD, 1)} USD");
            Console.WriteLine($"1 USD -> {Exchange(Currency.USD, Currency.RON, 1)} RON");
            Console.WriteLine($"1 USD -> {Exchange(Currency.USD, Currency.EUR, 1)} EUR");
        }
    }
}
