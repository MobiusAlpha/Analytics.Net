namespace Mathematics
{
    public class Integral : AnalyticOperation
    {
        public Expression Expression { get; }
        public Variable RespectTo { get; }
        public int Order { get; }

        public Integral(Expression expression, Variable respectTo, int order = 1)
        {
            Expression = expression;
            RespectTo = respectTo;
            Order = order;
        }

        public override string ToString()
        {
            return Solve().ToString();
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return Solve().Substitute(variable, operation).Root;
        }

        public Operation SolveDefinite(Variable variable, Operation lowerBound, Operation upperBound)
        {
            Expression solution = Solve();
            return new Arthmetic(solution.Substitute(variable, upperBound).Root, solution.Substitute(variable, lowerBound).Root, ArthmeticOperationType.Sub);
        }

        public override Expression Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}