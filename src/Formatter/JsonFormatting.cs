using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NLog;

namespace Formatter
{
    public class JsonFormatter : Formatter
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IConfigurationRoot _configurationRoot;

        public JsonFormatter(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new Exception($"File not found at provided path '{filePath}'.");

            _configurationRoot = new ConfigurationBuilder()
                                 .AddJsonFile(filePath, false)
                                 .Build()
                    ;
        }

        public override IEnumerable<KeyValuePair<string, string>> GetSettings()
        {
            try
            {
                return _configurationRoot.AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to get configuration settings. {ex.Message}");
                return Enumerable.Empty<KeyValuePair<string, string>>();
            }
        }
    }
}