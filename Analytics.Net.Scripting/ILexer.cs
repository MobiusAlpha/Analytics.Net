namespace Analytics.Net.Scripting
{
    public interface ILexer
    {
        LexicalToken[] Lex(Token[] tokens);
        LexicalToken Lex(Token token);
    }
}