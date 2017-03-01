using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class Time : IDimension
    {

        public static IEnumerable<BaseDimension> BaseDimensions { get; } = new[] { BaseDimension.Time };
        public static Unit<Time> BaseUnit { get; } = Unit<Time>.Second;

    }

    public partial class Unit<T>
    {

        public static Unit<Time> Second = new Unit<Time>(Prefixes._);
        public static Unit<Time> Millisecond = new Unit<Time>(Prefixes.Milli);
        public static Unit<Time> Minute = new Unit<Time>(60M);
        public static Unit<Time> Hour = new Unit<Time>(3600M);
        public static Unit<Time> Day = new Unit<Time>(864000M);
    }
}