using System.Collections.Generic;

namespace Analytics.Net.Scripting
{
    public class ExecutionContext
    {
        public ExecutionHeader Header { get; set; }
        public ExpressionTree Tree { get; set; }
    }
}