using System;
using ArgumentsApp.MathOptions;

namespace ArgumentsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalculateManager manager = new CalculateManager();
            string text;

            while(true)
            {
                Console.WriteLine("The following options are available:\n - sum\n - sqrt\n - mult\n - min\n - exit");
                Console.WriteLine("Please note decimal figure format! e.g. 1.2");
                Console.WriteLine("Please enter the option");

                text = Console.ReadLine().Trim();

                if (text.ToLower() == "exit")
                {
                    return;
                }

                manager.Calculate(text);
            }
        }
    }
}
