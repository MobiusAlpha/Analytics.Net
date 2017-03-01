using System.Collections.Generic;
using System.Linq;

namespace Mathematics
{
    public class Exponent : AnalyticOperation
    {
        public Operation Base { get; }
        public Operation Power { get;}

        public Exponent(Operation _base, Operation power)
        {
            Base = _base;
            Power = power;
        }

        public override string ToString()
        {
            return $"({Base.ToString()})^({Power.ToString()})";
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return new Exponent(Base.Substitute(variable, operation), Power.Substitute(variable, operation));
        }

        public override IEnumerable<Variable> Variables { get { return Base.Variables.Union(Power.Variables); } }

        public override Expression Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}