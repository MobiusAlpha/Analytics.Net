using System;
using System.Collections.Generic;

namespace Mathematics
{
    public class Symbol : Constant
    {
        public char Symb { get; }
        public Guid VarId { get; }
        public override double Value { get; }

        private static readonly Dictionary<char, Guid> VarStore = new Dictionary<char, Guid>();
        private static readonly Dictionary<Guid, double> ValStore = new Dictionary<Guid, double>();
        private static readonly object _lockObj = new object();

        private Symbol(char symbol, double value)
        {
            Symb = symbol;
            Value = value;

            lock (_lockObj)
            {
                if (VarStore.ContainsKey(symbol))
                {
                    VarId = VarStore[symbol];
                    Value = ValStore[VarId];
                }
                else
                {
                    VarId = VarStore[symbol] = Guid.NewGuid();
                    Value = ValStore[VarId] = value;
                }
            }
        }

        public static Symbol Define(char symbol, double value)
        {
            lock (_lockObj)
            {
                if (!VarStore.ContainsKey(symbol))
                {
                    return new Symbol(symbol, value);
                }

                throw new InvalidOperationException("Symbol cannot be redefined.");
            }
        }

        public static Symbol Infinity { get; } = new Symbol('\u221E', Double.PositiveInfinity);
        public static Symbol Pi { get; } = new Symbol('\u03C0', Math.PI);
    }
}