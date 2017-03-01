using System;

namespace Analytics.Net.Dimensions
{
    public partial class Unit<T> where T : IDimension
    {
        public Func<decimal, decimal> ConversionFormula { get; }
        public Func<decimal, decimal> RevertFormula { get; }

        private Unit(double conversionFactor) : this((decimal) conversionFactor)
        {

        }

        private Unit(decimal conversionFactor) : this(prevalue => prevalue * conversionFactor, postvalue => postvalue / conversionFactor)
        {
        }

        private Unit(Func<decimal, decimal> conversionFormula, Func<decimal, decimal> revertFormula)
        {
            ConversionFormula = conversionFormula;
            RevertFormula = revertFormula;
        }
    }
}