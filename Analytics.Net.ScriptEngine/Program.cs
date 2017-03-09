using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Analytics.Net.Dimensions;
using Analytics.Net.Scripting;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Analytics.Net.ScriptEngine
{
    public class Program
    {
        static int Main(string[] args)
        {
            if (args == null || args.Length < 1)
            {
                Console.WriteLine("");
                return 1;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("");
                return 2;
            }

            Dictionary<char, DimensionalQuantity> definitions = new Dictionary<char, DimensionalQuantity>();

            foreach (var arg in args.Skip(1))
            {
                if (!Regex.IsMatch(arg, @""))
                {
                    Console.WriteLine("");
                    return 3;
                }

                string[] argParts = arg.Split('=');

                definitions[char.Parse(argParts[0])] = DimensionalQuantity.Parse(argParts[1]);
            }

            IWindsorContainer container = new WindsorContainer();

            container.Install(new ContainerInstaller());

            FileInfo file = new FileInfo(args[0]);

            IExecutionEngine engine = container.Resolve<IExecutionEngine>();

            ExecutionResult result;

            switch (file.Extension.ToUpper())
            {
                case "ANS":
                    {
                        ITokenizer tokenizer = container.Resolve<ITokenizer>();

                        ILexer lexer = container.Resolve<ILexer>();

                        IParser parser = container.Resolve<IParser>();

                        string content;

                        using (StreamReader reader = new StreamReader(file.OpenRead()))
                        {
                            content = reader.ReadToEnd();
                        }

                        Token[] tokens = tokenizer.Tokenize(content);

                        LexicalToken[] lexTokens = lexer.Lex(tokens);

                        ExecutionContext context = parser.Parse(lexTokens);

                        result = engine.Execute(context, definitions);
                    }
                    break;
                case "ANC":
                    {
                        List<byte> content = new List<byte>();

                        using (BinaryReader reader = new BinaryReader(file.OpenRead()))
                        {
                            for (int count = 0; count < file.Length; count += 1024)
                            {
                                byte[] buffer = new byte[1024];

                                reader.Read(buffer, count, 1024);

                                content.AddRange(buffer);
                            }
                        }

                        result = engine.Execute(content.ToArray(), definitions);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("");
                        return 3;
                    }
            }

            foreach (var log in result.Log)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                switch (log.Level)
                {
                    case Level.Debug:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Level.Info:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case Level.Warn:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Level.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Level.Fatal:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                }

                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{result.Code}.{result.Subcode} - {result.Message}");

            return result.Code;
        }
    }

    public class ContainerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            throw new NotImplementedException();
        }
    }
}
