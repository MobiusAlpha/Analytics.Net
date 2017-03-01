using System;

namespace Mathematics
{
    public class Sigma : AnalyticOperation
    {
        public Operation Operation { get; set; }
        public Variable SummationVariable { get; set; }
        public double Start { get; set; }
        public double Increment { get; set; }
        public double End { get; set; }

        public Sigma(Operation operation, Variable summationVariable, double start, double end, double increment = 1)
        {
            if (Math.Sign(end - start) != Math.Sign(increment))
            {
                throw new InvalidOperationException("Increment cannot cause an infinite loop!");
            }

            Operation = operation;
            SummationVariable = summationVariable;
            Start = start;
            Increment = increment;
            End = end;
        }

        public override string ToString()
        {
            return $"\u03A3[{SummationVariable.Symb}={Start}, {End}]({Operation.ToString()})";
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return Solve().Substitute(variable, operation).Root;
        }

        public override Expression Solve()
        {
            Operation op = Operation.Substitute(SummationVariable, new Constant(Start));

            for (double i = Start + Increment; i <= End; i += Increment)
            {
                op = new Arthmetic(op, Operation.Substitute(SummationVariable, new Constant(i)), ArthmeticOperationType.Add);
            }

            return new Expression(op);
        }
    }
}