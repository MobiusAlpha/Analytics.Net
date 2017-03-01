namespace Mathematics
{
    public class Equation
    {
        public Expression Left { get; }
        public Expression Right { get; }
        public Operator Operator { get; }

        public Equation(Expression left, Expression right, Operator op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }

        public Equation Substitute(Variable variable, Operation operation)
        {
            return  new Equation(Left.Substitute(variable, operation).Root.Solve(), Right.Substitute(variable, operation).Root.Solve(), Operator);
        }

        public Expression Isolate(Variable variable)
        {
            
        }
    }
}