using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ArgumentsApp.MathOptions;

namespace ArgumentsApp
{
    public class CalculateManager
    {
        private Dictionary<string, ICalculate> options = new Dictionary<string, ICalculate>(StringComparer.OrdinalIgnoreCase);

        public CalculateManager()
        {
            options.Add("sum", new Sum());
            options.Add("+", new Sum());
            options.Add("min", new Min());
            options.Add("sqrt", new Sqrt());
            options.Add("^", new Sqrt());
            options.Add("mult", new Mult());
            options.Add("*", new Mult());
        }

        public void Calculate(string data)
        {
            if (data.Contains(","))
            {
                Console.WriteLine("Wrong figure format! Correct is following: 1.2");
                return;
            }

            try
            {
                int indexStart = data.IndexOf(" ");
                string option = data.Substring(0, indexStart);

                var value = options.First(x => x.Key == option).Value;

                int lenght = data.Length - indexStart;
                string figures = data.Substring(indexStart + 1, lenght - 1);

                string[] itemsArray = figures.Split(' ');
                List<double> list = new List<double>(); 

                for (int i = 0; i < itemsArray.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(itemsArray[i]))
                    {
                        list.Add(double.Parse(itemsArray[i].Trim(), CultureInfo.GetCultureInfo("en-us")));
                    }
                }

                double result = value.Calculate(list.ToArray());

                Console.WriteLine("The result is: " + result + "\n");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Wrong input! Enter whitespace between argument and figure.\n");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error! Wrong format!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message + "\n");
            }
        }
    }
}
