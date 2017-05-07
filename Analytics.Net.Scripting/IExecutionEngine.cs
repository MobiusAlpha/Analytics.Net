using System;
using System.Collections.Generic;
using System.Linq;
using Analytics.Net.Dimensions;

namespace Analytics.Net.Scripting
{
    public interface IExecutionEngine
    {
        ExecutionResult Execute(ExecutionContext context, Dictionary<char, DimensionalQuantity> values);
        ExecutionResult Execute(byte[] byteCode, Dictionary<char, DimensionalQuantity> values);
    }

    public class ExecutionEngine : IExecutionEngine
    {
        readonly Stack<Frame> Stackframes = new Stack<Frame>();
        Frame Current { get { return Stackframes.Any() ? Stackframes.Peek() : null; } }
        private Frame Global { get; } = new Frame();

        public ExecutionResult Execute(ExecutionContext context, Dictionary<char, DimensionalQuantity> values)
        {

            ExecutionResult result = RunExecution(context.Tree.ExpressionChain) as ExecutionResult;

            return result;
        }

        private object RunExecution(List<Expression> expressionChain)
        {
            Stackframes.Push(new Frame());

            object returnValue = null;

            try
            {
                foreach (Expression expr in expressionChain)
                {
                    returnValue = Execute(expr);

                    if (expr is Return)
                    {
                        break;
                    }
                }

                return returnValue;
            }
            finally
            {
                Stackframes.Pop();
            }
        }

        private object Execute(Expression expression)
        {
            if (expression is Invoke)
            {
                Invoke invocation = expression as Invoke;

                Definition def;

                if (invocation.Symbol.StartsWith("$"))
                {
                    def = Global.Definitions[invocation.Symbol.Substring(1)];
                }
                else
                {
                    def = Current.Definitions[invocation.Symbol];
                }

                if (def is Function)
                {
                    Function func = def as Function;

                    return RunExecution(func.ExpressionChain);
                }
                else if (def is Subroutine)
                {
                    Subroutine sub = def as Subroutine;

                    RunExecution(sub.ExpressionChain);

                    return null;
                }
                else
                {
                    throw new ExecutionException();
                }

            }
            else if (expression is Conditional)
            {
                Conditional cndtl = expression as Conditional;

                bool result = (bool)Execute(cndtl.Condition);

                if (result)
                {
                    return RunExecution(cndtl.AffirmativeExpressionChain);
                }
                else
                {
                    return RunExecution(cndtl.NegativeExpressionChain);
                }
            }
            else if (expression is Return)
            {
                return Execute(((Return)expression).Expression);
            }
            else if (expression is Operation)
            {
                Operation operation = expression as Operation;

                if (operation is Define)
                {
                    
                }
                else if (operation is Access)
                {
                    Access access = operation as Access;

                    Definition def;

                    if (access.Symbol.StartsWith("$"))
                    {
                        def = Global.Definitions[access.Symbol.Substring(1)];
                    }
                    else
                    {
                        def = Current.Definitions[access.Symbol];
                    }


                }
                else if (operation is Assignment)
                {
                    Assignment assn = operation as Assignment;

                    Variable var;

                    if (assn.Target.StartsWith("$"))
                    {
                        var = Global.Definitions[assn.Target.Substring(1)] as Variable;
                    }
                    else
                    {
                        var = Current.Definitions[assn.Target] as Variable;
                    }

                    if (var == null)
                    {
                        throw new ExecutionException();
                    }

                    var.Value = new Value()
                    {
                        Type = var.Type,
                        Content = Execute(assn.Source)
                    };
                }
            }

            return null;
        }

        public ExecutionResult Execute(byte[] byteCode, Dictionary<char, DimensionalQuantity> values)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Frame
    {
        public Dictionary<string, Definition> Definitions { get; } = new Dictionary<string, Definition>();
    }

    public class ExecutionException : Exception
    {

    }

    public abstract class Expression
    {

    }

    public class Conditional : Expression
    {
        public Expression Condition { get; set; }
        public List<Expression> AffirmativeExpressionChain { get; set; }
        public List<Expression> NegativeExpressionChain { get; set; }
    }

    public class Invoke : Expression
    {
        public string Symbol { get; set; }
    }

    public class Return : Expression
    {
        public Expression Expression { get; set; }
    }

    public abstract class Operation : Expression
    {

    }

    public class Define : Operation
    {
        public string Symbol { get; set; }
    }

    public class Assignment : Operation
    {
        public string Target { get; set; }
        public Expression Source { get; set; }
    }

    public class Access : Operation
    {
        public string Symbol { get; set; }
    }

    public abstract class Definition
    {
        public string Symbol { get; set; }
    }

    public class Variable : Definition
    {
        public Value Value { get; set; }
        public Type Type { get; set; }
    }

    public class Property : Definition
    {
        public List<Expression> ExpressionChain { get; set; }
        public Type ReturnType { get; set; }
    }

    public class Subroutine : Definition
    {
        public List<Expression> ExpressionChain { get; set; }
    }

    public class Function : Definition
    {
        public List<Expression> ExpressionChain { get; set; }
        public Dictionary<string, Type> Parameters { get; set; }
        public Type ReturnType { get; set; }
    }

    public class Value
    {
        public Type Type { get; set; }
        public Object Content { get; set; }
    }

    public enum Type
    {
        
    }
}