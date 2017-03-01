using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class Variable : Operation, IEquatable<Variable>, IEqualityComparer<Variable>
    {
        public char Symb { get; }
        public Guid VarId { get; }

        private static readonly Dictionary<char, Guid> VarStore = new Dictionary<char, Guid>();
        private static readonly object _lockObj = new object();
        public Variable(char symbol)
        {
            Symb = symbol;

            lock (_lockObj)
            {
                if (VarStore.ContainsKey(symbol))
                {
                    VarId = VarStore[symbol];
                }
                else
                {
                    VarId = VarStore[symbol] = Guid.NewGuid();
                }
            }
        }

        public bool Equals(Variable other)
        {
            return VarId == other?.VarId;
        }

        public bool Equals(Variable x, Variable y)
        {
            return x.VarId == y.VarId;
        }

        public int GetHashCode(Variable obj)
        {
            return obj.VarId.GetHashCode();
        }

        public static Variable _(char Symbol)
        {
            return new Variable(Symbol);
        }

        public override double Solve(IDictionary<Variable, Operation> values)
        {
            if (values.ContainsKey(this))
            {
                return values[this].Solve(values);
            }
            else
            {
                throw new InvalidOperationException("Values does not contain necessary value for a numerical solution.");
            }
        }

        public override string ToString()
        {
            return $"{Symb}";
        }

        public override Operation Substitute(Variable variable, Operation operation)
        {
            return variable.Equals(this) ? operation : this;
        }

        public override IEnumerable<Variable> Variables { get { return new Variable[] { this }; } }

        public static Variable X { get { return _('X'); } }
        public static Variable Y { get { return _('Y'); } }
        public static Variable Z { get { return _('Z'); } }
        public static Variable T { get { return _('T'); } }
        /// <summary>
        /// Standard variable for calculus limits
        /// </summary>
        public static Variable h { get { return _('h'); } }
    }
}
