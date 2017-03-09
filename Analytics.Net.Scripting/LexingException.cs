using System;

namespace Analytics.Net.Scripting
{
    public class LexingException : Exception
    {
        public LexingException(string invalidToken) : base($"The token '{invalidToken}' was not validly lexed.")
        {

        }
    }
}