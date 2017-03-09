using System;

namespace Analytics.Net.Scripting
{
    public interface IParser
    {
        ExecutionContext Parse(LexicalToken[] lexTokens);
    }

    public class ParsingException : Exception
    {
        public ParsingException(string message) : base(message)
        {
            
        }
    }
}