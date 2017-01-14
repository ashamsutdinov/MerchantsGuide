using System;

namespace MerchantsGuide
{
    public class Program
    {
        private static void Main()
        {
            var digit = "MMMMCMXCIX";
            var dec = RomanNumberParser.Parse(digit);
            Console.WriteLine("{0} {1}",digit,dec);
            Console.ReadKey();
        }
    }
}