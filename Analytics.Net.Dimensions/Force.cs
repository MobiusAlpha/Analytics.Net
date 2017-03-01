using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Force : IDimension
    {

        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Mass, BaseDimension.Length, BaseDimension.InvTime, BaseDimension.InvTime };
        public static Unit<Force> BaseUnit { get; } = Unit<Force>.Millinewton;
    }

    public partial class Unit<T>
    {
        public static Unit<Force> Newton { get; } = new Unit<Force>(Prefixes.Kilo);
        public static Unit<Force> Pound { get; } = new Unit<Force>(4448M);
        public static Unit<Force> Millinewton { get; } = new Unit<Force>(Prefixes._);
    }
}