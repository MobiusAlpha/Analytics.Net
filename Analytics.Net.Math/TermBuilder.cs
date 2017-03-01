namespace Mathematics
{
    public class TermBuilder
    {
        private Term term;
        private TermBuilder()
        {
            term = new Term();
        }

        public static TermBuilder Coefficient_(double coefficient)
        {
            TermBuilder builder = new TermBuilder();
            builder.term.Coefficient = new Constant(coefficient);
            return builder;
        }

        public static TermBuilder Variable_(Variable variable, Operation power)
        {
            TermBuilder builder = new TermBuilder();
            builder.term.TermVariables[variable] = power;
            return builder;
        }

        public static TermBuilder EulerPower_(Term power)
        {
            TermBuilder builder = new TermBuilder();
            builder.term.EulerPower = power;
            return builder;
        }

        public TermBuilder Coefficient(double coefficient)
        {
            term.Coefficient = new Constant(coefficient);
            return this;
        }

        public TermBuilder Variable(Variable variable, Operation power)
        {
            term.TermVariables[variable] = power;
            return this;
        }

        public TermBuilder EulerPower(Term power)
        {
            term.EulerPower = power;
            return this;
        }

        public Term Get()
        {
            return term;
        }
    }
}