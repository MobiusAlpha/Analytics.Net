using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analytics.Net.Scripting
{
    public class Lexer : ILexer
    {
        private static readonly Regex _alphaNumeric = new Regex("", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex _numeric = new Regex(@"^\d+?\.?\d+?\s?([A-Za-z\*\/]|(\^\d+?))*?$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex _operator = new Regex(@"^([!<>=/\^+\-\*][=]?)$|^([<>][<>])$|^#$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex _boundary = new Regex(@"^\(|\)|\{|\}|\[|\]|\;|\:|\'|\""|\`$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex _label = new Regex(@"^[_A-Za-z]\w*?$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex _directive = new Regex(@"^#[_A-Za-z]\w*?$", RegexOptions.Compiled | RegexOptions.Multiline);

        public LexicalToken[] Lex(Token[] tokens)
        {
            List<LexicalToken> lexTokens = new List<LexicalToken>();

            foreach (var token in tokens)
            {
                Lex(token);
            }

            return lexTokens.ToArray();
        }

        public LexicalToken Lex(Token token)
        {
            LexicalToken lexToken;
            if (_numeric.IsMatch(token.Value))
            {
                lexToken = new LexicalToken()
                {
                    Value = token.Value,
                    Position = token.Position,
                    Type = TokenType.Numeric
                };

            }
            //else if (_alphaNumeric.IsMatch(token.Value))
            //{
            //    lexToken = new LexicalToken()
            //    {
            //        Value = token.Value,
            //        Position = token.Position,
            //        Type = TokenType.AlphaNumeric
            //    };
            //}
            else if (_operator.IsMatch(token.Value))
            {
                lexToken = new LexicalToken()
                {
                    Value = token.Value,
                    Position = token.Position,
                    Type = TokenType.Operator
                };

            }
            else if (_boundary.IsMatch(token.Value))
            {
                lexToken = new LexicalToken()
                {
                    Value = token.Value,
                    Position = token.Position,
                    Type = TokenType.Boundary
                };

            }
            else if (_label.IsMatch(token.Value))
            {
                lexToken = new LexicalToken()
                {
                    Value = token.Value,
                    Position = token.Position,
                    Type = TokenType.Label
                };

            }
            else if (_directive.IsMatch(token.Value))
            {
                lexToken = new LexicalToken()
                {
                    Value = token.Value,
                    Position = token.Position,
                    Type = TokenType.Label
                };

            }
            else
            {
                throw new LexingException(token.Value);
            }

            return lexToken;
        }
    }
}