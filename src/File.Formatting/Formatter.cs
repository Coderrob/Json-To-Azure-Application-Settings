using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FileFormatting
{
    public abstract class Formatter : IFormatter
    {
        private readonly ILogger<Formatter> _logger;

        protected Formatter(ILogger<Formatter> logger)
        {
            _logger = logger;
        }

        public async Task WriteToFile(string filePath)
        {
            _logger.LogInformation($"Writing settings to file '{filePath}'.");

            var settings = GetSettings();

            using (var file = File.CreateText(filePath))
            {
                foreach (var (key, value) in settings)
                {
                    await file.WriteLineAsync($"{key},{value}");
                }
            }
        }

        public abstract IEnumerable<KeyValuePair<string, string>> GetSettings();

        public abstract Formatter Load(string filePath);
    }
}