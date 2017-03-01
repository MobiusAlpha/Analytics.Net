using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Area : IDimension
    {
        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Length, BaseDimension.Length,  };
        public static Unit<Area> BaseUnit { get; } = Unit<Area>.SquareMeter;
    }

    public partial class Unit<T>
    {
        public static Unit<Area> SquareMeter { get; } = new Unit<Area>(Prefixes._);
        public static Unit<Area> Acre { get; } = new Unit<Area>(4047M);
        public static Unit<Area> Hectare { get; } = new Unit<Area>(10000M);
        public static Unit<Area> Hide { get; } = new Unit<Area>(485625M);
        public static Unit<Area> SquareKilometer { get; } = new Unit<Area>(Prefixes.Kilo * Prefixes.Kilo);
    }
}