using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ArgumentApp;

namespace ArgumentsApp
{
    public class CalculateManager
    {
        public Dictionary<string, ICalculate> options { get; set; }

        public CalculateManager(Dictionary<string, ICalculate> items)
        {
            this.options = items;
        }

        public double? Calculate(string data, out Exception exception)
        {
            data = data.Trim();
            exception = null;

            if (data.Contains(","))
            {
                Console.WriteLine("Wrong figure format! Correct is as following: 1.2");
                return null;
            }

            try
            {
                var mathOption = OptionIdentification(data);
                Logger.Instance.Info("Option Identification is successful");

                double[] figures = FiguresIdentification(data);
                Logger.Instance.Info("Figures Identification is successful");

                double result = mathOption.Calculate(figures);
                Logger.Instance.Info("Calculation is successful");

                return result;
            }
            catch (InvalidOperationException ex)
            {
                exception = ex;
                Console.WriteLine("Wrong input!");
                Logger.Instance.Warning(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                exception = ex;
                Console.WriteLine("Error! Wrong format!\n");
                Logger.Instance.Warning(ex);
            }
            catch (Exception ex)
            {
                exception = ex;
                Console.WriteLine("Error! " + ex.Message + "\n");
                Logger.Instance.Error(ex);
            }
            return null;
        }

        private ICalculate OptionIdentification(string data)
        {
            int optionLength = data.IndexOf(" ");
            string option = data.Substring(0, optionLength);
            var mathOption = options.First(x => x.Key == option.ToLower()).Value;

            return mathOption;
        }

        private double[] FiguresIdentification(string data)
        {
            int optionLength = data.IndexOf(" ");
            int figuresLenght = data.Length - optionLength;
            string figures = data.Substring(optionLength + 1, figuresLenght - 1);

            string[] itemsArray = figures.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            double[] result = new double[itemsArray.Length];

            for (int i = 0; i < itemsArray.Length; i++)
            {
                result[i] = double.Parse(itemsArray[i].Trim(), CultureInfo.GetCultureInfo("en-us"));
            }

            return result;
        }
    }
}
