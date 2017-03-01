namespace Mathematics
{
    public class Expression
    {
        public Expression(Operation rootOperation)
        {
            Root = rootOperation;
        }

        public Operation Root { get; }

        public Expression Substitute(Variable variable, Operation operation)
        {
            return new Expression(Root.Substitute(variable, operation));
        }
    }
}