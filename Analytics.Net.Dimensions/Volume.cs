using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Volume : IDimension
    {

        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Length, BaseDimension.Length, BaseDimension.Length,  };
        public static Unit<Volume> BaseUnit { get; } = Unit<Volume>.CubicMeter;
    }

    public partial class Unit<T>
    {
        public static Unit<Volume> Liter = new Unit<Volume>(0.001M);
        public static Unit<Volume> Milliliter = new Unit<Volume>(0.001M * Prefixes.Milli);
        public static Unit<Volume> CubicMeter = new Unit<Volume>(Prefixes._);
        public static Unit<Volume> Kiloliter = new Unit<Volume>(1M);
        public static Unit<Volume> Gallon = new Unit<Volume>(0.003785);
        public static Unit<Volume> Cup = new Unit<Volume>(2.366E-4);
        public static Unit<Volume> Quart = new Unit<Volume>(9.464E-4);
    }
}