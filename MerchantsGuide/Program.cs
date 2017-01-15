using System;
using System.IO;

namespace MerchantsGuide
{
    public class Program
    {
        private static void Main()
        {
            var context = new ProblemContext();
            using (var sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        context.ProcessLine(line);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}