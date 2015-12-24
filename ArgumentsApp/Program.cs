using System;
using ArgumentApp;

namespace ArgumentsApp
{
    public class Program
    {
        static void Main()
        {
            var options = Settings.GetOptions();
            Logger.Instance.Info("Options are added successfully");

            CalculateManager manager = new CalculateManager(options);

            while (true)
            {
                Console.WriteLine("The following options are available:\n - sum\n - sqrt\n - mult\n - min\n - exit");
                Console.WriteLine("Please note decimal figure format! e.g. 1.2");
                Console.WriteLine("Please enter the option");

                string text = Console.ReadLine();

                if (text.ToLower() == "exit")
                {
                    return;
                }
                Exception exception;
                var result = manager.Calculate(text, out exception);

                if (result != null)
                {
                    Console.WriteLine("The result is: " + result + "\n");
                }
            }
        }
    }
}
