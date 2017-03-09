using System.Collections.Generic;
using Analytics.Net.Dimensions;

namespace Analytics.Net.Scripting
{
    public interface IExecutionEngine
    {
        ExecutionResult Execute(ExecutionContext context, Dictionary<char, DimensionalQuantity> values);
        ExecutionResult Execute(byte[] byteCode, Dictionary<char, DimensionalQuantity> values);
    }
}