using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Acceleration : IDimension
    {

        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Length, BaseDimension.InvTime, BaseDimension.InvTime,  };

        public static Unit<Acceleration> BaseUnit { get; } = Unit<Time>.MetersPerSecondSq;
    }

    public partial class Unit<T>
    {
        public static Unit<Acceleration> MetersPerSecondSq { get; } = new Unit<Acceleration>(Prefixes._);
        public static Unit<Acceleration> Earth_G { get; } = new Unit<Acceleration>(9.8M);
        public static Unit<Acceleration> FeetPerSecondSq { get; } = new Unit<Acceleration>(0.3048M);
        public static Unit<Acceleration> Moon_G { get; } = new Unit<Acceleration>(1.624M);
    }
}