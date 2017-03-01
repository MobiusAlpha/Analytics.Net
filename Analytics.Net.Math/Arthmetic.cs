using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Mathematics
{
    public class Arthmetic : Operation
    {
        public Operation Op1 { get; }
        public Operation Op2 { get; }
        public ArthmeticOperationType OperationType { get; }

        public Arthmetic(Operation op1, Operation op2, ArthmeticOperationType operationType)
        {
            Op1 = op1;
            Op2 = op2;
            OperationType = operationType;
        }

        public override double Solve(IDictionary<Variable, Operation> values)
        {
            switch (OperationType)
            {
                case ArthmeticOperationType.Add:
                    return Op1.Solve(values) + Op2.Solve(values);
                case ArthmeticOperationType.Div:
                    return Op1.Solve(values) / Op2.Solve(values);
                case ArthmeticOperationType.Mod:
                    return Op1.Solve(values) % Op2.Solve(values);
                case ArthmeticOperationType.Mult:
                    return Op1.Solve(values) * Op2.Solve(values);
                case ArthmeticOperationType.Sub:
                    return Op1.Solve(values) - Op2.Solve(values);
                default:
                    throw new InvalidEnumArgumentException(nameof(OperationType));
            }
                
        }

        public override Expression Solve()
        {
            switch (OperationType)
            {
                case ArthmeticOperationType.Add:
                    return Op1.Solve() + Op2.Solve();
                case ArthmeticOperationType.Div:
                    return Op1.Solve() / Op2.Solve();
                case ArthmeticOperationType.Mod:
                    return Op1.Solve() % Op2.Solve();
                case ArthmeticOperationType.Mult:
                    return Op1.Solve() * Op2.Solve();
                case ArthmeticOperationType.Sub:
                    return Op1.Solve() - Op2.Solve();
                default:
                    throw new InvalidEnumArgumentException(nameof(OperationType));
            }
        }

        public override string ToString()
        {
            switch (OperationType)
            {
                case ArthmeticOperationType.Add:
                    return $"({Op1.ToString()}) + ({Op2.ToString()})";
                case ArthmeticOperationType.Div:
                    return $"({Op1.ToString()}) / ({Op2.ToString()})";
                case ArthmeticOperationType.Mod:
                    return $"({Op1.ToString()}) % ({Op2.ToString()})";
                case ArthmeticOperationType.Mult:
                    return $"({Op1.ToString()}) * ({Op2.ToString()})";
                case ArthmeticOperationType.Sub:
                    return $"({Op1.ToString()}) - ({Op2.ToString()})";
                default:
                    throw new InvalidEnumArgumentException(nameof(OperationType));
            }
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return new Arthmetic(Op1.Substitute(variable, operation), Op2.Substitute(variable, operation), OperationType);
        }

        public override IEnumerable<Variable> Variables { get { return Op1.Variables.Union(Op2.Variables); } }
    }
}