using System.Linq;

namespace Analytics.Net.Scripting
{
    public interface ITokenizer
    {
        Token[] Tokenize(string source);
    }
}