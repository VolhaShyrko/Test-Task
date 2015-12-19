using System.Linq;

namespace ArgumentsApp.MathOptions
{
    public class Min : ICalculate
    {
        public double Calculate(double[] array)
        {
            double min = array.Min();
            return min;
        }
    }
}
