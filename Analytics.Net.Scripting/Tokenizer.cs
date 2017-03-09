using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analytics.Net.Scripting
{
    public class Tokenizer : ITokenizer
    {
        static readonly Regex TokenRegex = new Regex(@"(\w+)|([<>=][<>=]?)|(\|\|?)|(\&\&?)|(\(|\)|\{|\})|[:;,\s%@!$]|([\?\+\-\*\/\^\[\]]=?)|\.", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public Token[] Tokenize(string source)
        {
            List<Token> tokens = new List<Token>();

            MatchCollection matches = TokenRegex.Matches(source);

            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    tokens.Add(new Token() { Value = capture.Value, Position = capture.Index });
                }
            }

            return tokens.ToArray();
        }
    }
}