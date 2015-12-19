namespace ArgumentsApp.MathOptions
{
    public class Mult : ICalculate
    {
        public double Calculate(double[] array)
        {
            double mult = 1;

            foreach (double item in array)
            {
                mult = mult * item;
            }

            return mult;

            //return array.Aggregate<double, double>(1, (current, item) => current * item); //working option with Linq
        }
    }
}
