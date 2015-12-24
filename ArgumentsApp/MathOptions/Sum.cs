using System.Linq;

namespace ArgumentsApp.MathOptions
{
    public class Sum : ICalculate
    {
        public double Calculate(double[] array)
        {
            double sum = array.Sum();
            return sum;
        }
    }
}
