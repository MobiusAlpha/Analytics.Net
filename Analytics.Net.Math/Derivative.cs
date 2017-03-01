using System.Collections.Generic;

namespace Mathematics
{
    public class Derivative : AnalyticOperation
    {
        public Expression Expression { get; }
        public Variable RespectTo { get; set; }
        public int Order { get; set; }

        public Derivative(Expression expression, Variable respectTo, int order = 1)
        {
            Expression = expression;
            RespectTo = respectTo;
            Order = order;
        }

        public override Expression Solve()
        {
            var expr = Expression.Substitute(RespectTo, new Arthmetic(RespectTo, Variable.h, ArthmeticOperationType.Add));

            expr = new Limit(new Expression(new Arthmetic(new Arthmetic(expr.Root, Expression.Root,ArthmeticOperationType.Sub), Variable.h, ArthmeticOperationType.Div)), Variable.h, 0).Solve();

            return expr;
        }

        public override string ToString()
        {
            return Solve().ToString();
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return Solve().Substitute(variable, operation).Root;
        }

        public override IEnumerable<Variable> Variables { get { return Solve().Root.Variables; } }
    }
}