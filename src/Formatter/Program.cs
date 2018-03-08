using System;
using System.IO;
using NLog;

namespace Formatter
{
    internal class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            try
            {
                // args [0] - input file
                // args [1] - output file

                if (args.Length != 2)
                {
                    Console.WriteLine("Expected format of: <input-file-argument> <output-file-argument>");
                    return;
                }

                if (!File.Exists(args[0]))
                {
                    Console.WriteLine($"File not found at path '{args[0]}'");
                    return;
                }

                new JsonFormatter(args[0]).WriteToFile(args[1]).Wait();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to process settings file. {ex.Message}");
                Console.WriteLine("Failed to process settings file.");
            }
        }
    }
}