using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Vonage.Logger;
using Serilog;
using System;
using System.Reflection;

namespace DotnetCliCodeSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}]: {Message}\n")
                .CreateLogger();
            var factory = new LoggerFactory();
            factory.AddSerilog(log);
            LogProvider.SetLogFactory(factory);
            var snippet = string.Empty;
            var useAsync = false;
            var oSet = new OptionSet() { { "s|snippet=", "The Code Snippet you'd like to execute", v=> snippet=v },
            { "a|async=", "whether or not to use async", v=> useAsync=bool.Parse(v) }};

            var parsedArgs = oSet.Parse(args);

            var type = Type.GetType("DotnetCliCodeSnippets." + snippet);

            var runnableSnippet = (ICodeSnippet)Activator.CreateInstance(type);
            if (useAsync)
            {
                Console.WriteLine("running Async");
                runnableSnippet.ExecuteAsync().GetAwaiter().GetResult();
            }
            else
            {
                runnableSnippet.Execute();
            }            
        }
    }
}
