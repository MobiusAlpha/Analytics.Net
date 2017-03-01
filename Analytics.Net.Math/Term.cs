using System;
using System.Collections.Generic;
using System.Linq;

namespace Mathematics
{
    public class Term : Operation
    {
        public Constant Coefficient { get; internal set; }
        public Term EulerPower { get; internal set; }
        public IDictionary<Variable, Operation> TermVariables { get; }

        public Term(double coefficient, Variable variable, double power, Term eulerPower = null)
        {
            Coefficient = new Constant(coefficient);
            TermVariables = new Dictionary<Variable, Operation> { {variable, new Constant(power)} };
            EulerPower = eulerPower;
        }

        public Term()
        {
            TermVariables = new Dictionary<Variable, Operation>();
        }

        public override double Solve(IDictionary<Variable, Operation> values = null)
        {
            values = values ?? new Dictionary<Variable, Operation>();

            if (!TermVariables.All(p => values.ContainsKey(p.Key)))
            {
                throw new InvalidOperationException("All variables must be present for a numeric solution.");
            }

            return Coefficient.Value * TermVariables.Aggregate<KeyValuePair<Variable, Operation>, double>(0.0, (d, pair) => d * Math.Pow(values[pair.Key].Solve(values), pair.Value.Solve(values))) * (EulerPower != null ? Math.Pow(Math.E,EulerPower.Solve(TermVariables)) : 1);
        }

        public override Expression Solve()
        {
            foreach (Variable variable in TermVariables.Keys)
            {
                TermVariables[variable] = TermVariables[variable].Solve().Root;
            }

            return new Expression(this);
        }

        public override string ToString()
        {
            return $"{Coefficient}*{string.Join("*",TermVariables.Select(p => $"{p.Key}^{p.Value}"))}" + (EulerPower != null ? $"*e^({EulerPower.ToString()})" : String.Empty);
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            Term restructured = new Term();
            Operation op = null;

            foreach (var varSet in TermVariables)
            {
                if (varSet.Key != variable)
                {
                    restructured.TermVariables[varSet.Key] = varSet.Value.Substitute(variable, operation);
                }
                else
                {
                    op = new Exponent(variable.Substitute(variable, operation), TermVariables[variable].Substitute(variable, operation));
                }
            }

            if (op == null)
            {
                return restructured;
            }
            else
            {
                return op;
            }
        }

        public override IEnumerable<Variable> Variables { get { return TermVariables.Keys.Union(TermVariables.Values.SelectMany(val => val.Variables)); } }
    }
}