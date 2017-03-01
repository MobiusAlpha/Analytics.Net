using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Net.Dimensions
{
    public class Length : IDimension
    {
        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] {BaseDimension.Length};
        public static Unit<Length> BaseUnit { get; } = Unit<Length>.Meter;

        public static DimensionalQuantity From(Unit<Length> unit, decimal quantity)
        {
            return new DimensionalQuantity(unit.ConversionFormula(quantity), BaseDimension.Length);
        }
    }

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

            public static Unit<Length> Meter { get; } = new Unit<Length>(Prefixes._);
            public static Unit<Length> Inch { get; } = new Unit<Length>(0.3048);
            public static Unit<Length> Centimeter { get; } = new Unit<Length>(Prefixes.Centi);
            public static Unit<Length> Millimeter { get; } = new Unit<Length>(Prefixes.Milli);
            public static Unit<Length> Kilometer { get; } = new Unit<Length>(Prefixes.Kilo);
            public static Unit<Length> Mile { get; } = new Unit<Length>(1609.34);
            public static Unit<Length> Yard { get; } = new Unit<Length>(0.9144);
        }
}
