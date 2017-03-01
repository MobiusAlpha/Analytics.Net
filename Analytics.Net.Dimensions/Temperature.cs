using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Net.Dimensions
{
    public class Temperature : IDimension
    {
        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Temperature };
        public static Unit<Temperature> BaseUnit { get; } = Unit<Temperature>.Kelvin;
    }

    public partial class Unit<T>
    {
        public static Unit<Temperature> Kelvin { get; } = new Unit<Temperature>(Prefixes._);
        public static Unit<Temperature> Celsius { get; } = new Unit<Temperature>(pre => pre - 273.15M, post => post + 273.15M);
        public static Unit<Temperature> Fahrenheit { get; } = new Unit<Temperature>(pre => 5M / 9M * (pre - 32M) + 273.15M, post => 9M / 5M* (post - 273.15M) + 32M);
    }
}
