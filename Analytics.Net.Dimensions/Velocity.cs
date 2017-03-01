using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Velocity : IDimension
    {
        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Length, BaseDimension.InvTime,  };
        public static Unit<Velocity> BaseUnit { get; }
    }

    public partial class Unit<T>
    {
        public static Unit<Velocity> MeterPerSecond { get; } = new Unit<Velocity>(Prefixes._);
        public static Unit<Velocity> KilometerPerHour { get; } = new Unit<Velocity>(0.2778M);
        public static Unit<Velocity> MilesPerHour { get; } = new Unit<Velocity>(0.447M);
        public static Unit<Velocity> FeetPerSecond { get; } = new Unit<Velocity>(0.3048M);
        public static Unit<Velocity> Bubnoff { get; } = new Unit<Velocity>(3.171E-14);
        public static Unit<Velocity> FeetPerMinute { get; } = new Unit<Velocity>(0.00508M);
        public static Unit<Velocity> C { get; } = new Unit<Velocity>(2.998E8);
    }
}