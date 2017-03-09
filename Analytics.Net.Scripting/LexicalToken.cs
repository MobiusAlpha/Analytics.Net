namespace Analytics.Net.Scripting
{
    public class LexicalToken
    {
        public string Value { get; set; }
        public int Position { get; set; }
        public TokenType Type { get; set; }
    }
}