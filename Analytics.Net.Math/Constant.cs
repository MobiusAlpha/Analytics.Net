using System;
using System.Collections.Generic;

namespace Mathematics
{
    public class Constant : Operation, IEquatable<Constant>
    {
        public virtual double Value { get; }

        public Constant(double value)
        {
            Value = value;
        }

        protected Constant()
        {
            
        }

        public override double Solve(IDictionary<Variable, Operation> values)
        {
            return Value;
        }

        public override Expression Solve()
        {
            return new Expression(this);
        }

        public bool Equals(Constant other)
        {
            return Math.Abs(Value - other?.Value ?? 0) < double.Epsilon;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return this;
        }

        public override IEnumerable<Variable> Variables { get {return new Variable[0];} }
    }
}