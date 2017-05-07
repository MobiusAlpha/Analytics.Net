using System.Linq;

namespace Analytics.Net.Scripting
{
    public class AnalyticsParser : IParser
    {
        public ExecutionContext Parse(LexicalToken[] lexTokens)
        {
            ExecutionContext context = new ExecutionContext();

            LexicalToken[] _lexTokens = lexTokens;

            context.Header = _buildHeader(ref _lexTokens);
            context.Tree = _buildTree(_lexTokens);

            return context;
        }

        private ExecutionHeader _buildHeader(ref LexicalToken[] lexTokens)
        {
            bool parseComplete = false;
            bool started = false;

            ExecutionHeader header = new ExecutionHeader();

            for (int position = 0; position < lexTokens.Length; position++)
            {
                switch (lexTokens[position].Value.ToUpper())
                {
                    case "#HEADER_START":
                        {
                            if (!started)
                            {
                                started = true;
                            }
                            else
                            {
                                throw new ParsingException("Repeat of #HEADER_START token during parsing.");
                            }
                        }
                        break;
                    case "#HEADER_END":
                        {
                            if (started && _checkHeader(header))
                            {
                                parseComplete = true;
                            }
                            else if (!started)
                            {
                                throw new ParsingException("Encountered #HEADER_END without opening #HEADER_START.");
                            }
                            else
                            {
                                throw new ParsingException("Header parsing resulted in an incomplete header.");
                            }
                        }
                        break;
                    case "#RUN_MODE":
                        {
                            
                        }
                        break;
                    default:
                        throw new ParsingException($"Invalid token '{lexTokens[position].Value}' encountered during header parsing.");
                }

                if (parseComplete)
                {
                    lexTokens = lexTokens.Skip(position).ToArray();
                    break;
                }
            }

            if (!parseComplete)
            {
                throw new ParsingException("Invalid end of header, please verify that header information starts with #HEADER_START and ends with #HEADER_END.");
            }

            return header;
        }


        private bool _checkHeader(ExecutionHeader header)
        {
            return true;
        }

        private ExpressionTree _buildTree(LexicalToken[] lexTokens)
        {

        }
    }
}