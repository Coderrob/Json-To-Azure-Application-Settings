using System;
using NDesk.Options;

namespace Formatter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var showHelp = false;
            string output = null;
            string input = null;

            var p = new OptionSet
            {
                { "i=", "The input file", v => input = v },
                { "o=", "Specify the output file", v => output = v },
                { "h|help", "show this message and exit", v => showHelp = v != null }
            };

            try
            {
                p.Parse(args);

                new JsonFormatter(input).WriteToFile(output).Wait();
            }
            catch (OptionException e)
            {
                Console.Write("formatter: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `formatter --help' for more information.");
                return;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return;
            }

            Console.WriteLine("Options:");
            Console.WriteLine("\t Input File: {0}", input);
            Console.WriteLine("\tOuptut File: {0}", output);
        }

        private static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: formatter [OPTIONS]+");
            Console.WriteLine("Program to create a comma separated list of settings in Azure app settings formatting.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}