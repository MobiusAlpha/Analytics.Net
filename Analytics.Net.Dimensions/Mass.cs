using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Mass : IDimension
    {

        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Mass };
        public static Unit<Mass> BaseUnit { get; }
    }

    public partial class Unit<T>
    {
        public static Unit<Mass> Kilogram { get; } = new Unit<Mass>(Prefixes.Kilo);
        public static Unit<Mass> Slug { get; } = new Unit<Mass>(1.717E6);
        public static Unit<Mass> Gram { get; } = new Unit<Mass>(Prefixes._);
        public static Unit<Mass> Milligram { get; } = new Unit<Mass>(Prefixes.Milli);
    }
}