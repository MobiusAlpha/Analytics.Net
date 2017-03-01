using System.Collections.Generic;

namespace Mathematics
{
    public class Limit : AnalyticOperation
    {
        public Expression Expression { get; set; }
        public Variable RespectTo { get; set; }
        public double LimitVal { get; set; }

        public Limit(Expression expression, Variable respectTo, double limitVal)
        {
            Expression = expression;
            RespectTo = respectTo;
            LimitVal = limitVal;
        }

        public override string ToString()
        {
            return $"Lim[{RespectTo.Symb} \u2192 {LimitVal}]({Expression.Root.ToString()})";
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return new Limit(Expression.Substitute(variable, operation), RespectTo, LimitVal);
        }

        public override Expression Solve()
        {
            return Expression.Substitute(RespectTo, new Constant(LimitVal == 0 ? double.Epsilon : LimitVal));
        }
    }
}