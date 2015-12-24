using System.Collections.Generic;
using ArgumentsApp.MathOptions;

namespace ArgumentsApp
{
    public static class Settings
    {
        public static Dictionary<string, ICalculate> GetOptions()
        {
            Dictionary<string, ICalculate> options = new Dictionary<string, ICalculate>(); // extract to method

            options.Add("sum", new Sum());
            options.Add("+", new Sum());
            options.Add("min", new Min());
            options.Add("sqrt", new Sqrt());
            options.Add("^", new Sqrt());
            options.Add("mult", new Mult());
            options.Add("*", new Mult());

            return options;
        }
    }
}
