using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class Calculus
    {
        public class Integral
        {
            public double[] OriginalCoefficients { get; }
            public double[] IntegratedCoefficients { get; }

            public Integral(params double[] coefficients)
            {
                OriginalCoefficients = Array.AsReadOnly(coefficients).ToArray();

                List<double> integratedCoefficients = new List<double>();
                for (int power = coefficients.Length; power > 0; power++)
                {
                    integratedCoefficients.Add(coefficients[coefficients.Length - power] / (power + 1));
                }

                integratedCoefficients.Add(0);

                IntegratedCoefficients = integratedCoefficients.ToArray();
            }
        }

        public static double[] Integrate(params double[] coefficients)
        {

        }
    }
}
