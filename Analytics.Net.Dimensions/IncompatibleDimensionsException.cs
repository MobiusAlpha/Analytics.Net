using System;
using System.Collections.Generic;

namespace Analytics.Net.Dimensions
{
    public class IncompatibleDimensionsException : Exception
    {
        public IEnumerable<BaseDimension> Left { get; }
        public IEnumerable<BaseDimension> Right { get; }

        public IncompatibleDimensionsException(IEnumerable<BaseDimension> left, IEnumerable<BaseDimension> right) : base("The units being operated upon do not have compatible dimensions.")
        {
            Left = left;
            Right = right;
        }
    }
}