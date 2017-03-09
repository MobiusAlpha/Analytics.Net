using System;
using System.Collections.Generic;
using System.Linq;

namespace Analytics.Net.Dimensions
{
    public class DimensionalQuantity
    {
        public decimal Quantity { get; }
        public IEnumerable<BaseDimension> Dimensions { get; }

        internal DimensionalQuantity(decimal quantity, params BaseDimension[] dimensions)
        {
            Quantity = quantity;
            Dimensions = Array.AsReadOnly(dimensions);
        }

        public static DimensionalQuantity operator +(DimensionalQuantity a, DimensionalQuantity b)
        {
            if (!a.CheckCompatiblity(b))
            {
                throw new IncompatibleDimensionsException(a.Dimensions, b.Dimensions);
            }

            return new DimensionalQuantity(a.Quantity + b.Quantity, a.Dimensions.ToArray());
        }

        public static DimensionalQuantity operator -(DimensionalQuantity a, DimensionalQuantity b)
        {
            if (!a.CheckCompatiblity(b))
            {
                throw new IncompatibleDimensionsException(a.Dimensions, b.Dimensions);
            }

            return new DimensionalQuantity(a.Quantity - b.Quantity, a.Dimensions.ToArray());
        }

        public static DimensionalQuantity operator *(DimensionalQuantity a, DimensionalQuantity b)
        {
            decimal quantity = a.Quantity*b.Quantity;

            return new DimensionalQuantity(quantity, a.Dimensions.CombineDimensions(b.Dimensions).ToArray());
        }

        public static DimensionalQuantity operator /(DimensionalQuantity a, DimensionalQuantity b)
        {
            decimal quantity = a.Quantity / b.Quantity;

            return new DimensionalQuantity(quantity, a.Dimensions.DifferentiateDimensions(b.Dimensions).ToArray());
        }

        public static DimensionalQuantity Parse(string argPart)
        {
            throw new NotImplementedException();
        }
    }
}