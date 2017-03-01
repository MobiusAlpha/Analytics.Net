using System.Collections.Generic;

namespace Mathematics
{
    public abstract class Operation
    {
        public abstract double Solve(IDictionary<Variable, Operation> values);
        public abstract Expression Solve();
        public abstract string ToString();

        public abstract Operation Substitute(Variable variable, Operation operation);

        public abstract IEnumerable<Variable> Variables { get; }
    }

    public abstract class AnalyticOperation : Operation
    {
        public override double Solve(IDictionary<Variable, Operation> values)
        {
            return Solve().Root.Solve(values);
        }

        public override IEnumerable<Variable> Variables { get { return Solve().Root.Variables; } }
    }
}