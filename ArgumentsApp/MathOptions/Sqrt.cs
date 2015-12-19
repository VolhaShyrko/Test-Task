using System;

namespace ArgumentsApp.MathOptions
{
    public class Sqrt : ICalculate
    {
        public double Calculate(double[] array)
        {
            if (array.Length == 1)
            {
                double sqrt = Math.Sqrt(array[0]);

                return sqrt;
            }
            throw new ArgumentException("Only one figure can be processed!");
        }
    }
}
