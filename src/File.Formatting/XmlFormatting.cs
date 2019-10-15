using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FileFormatting
{
    public class XmlFormatting : Formatter
    {
        private readonly ILogger<XmlFormatting> _logger;
        private IConfigurationRoot _configurationRoot;

        public XmlFormatting(ILogger<XmlFormatting> logger) : base(logger)
        {
            _logger = logger;
        }

        public override Formatter Load(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new Exception($"File not found at provided path '{filePath}'.");

            _configurationRoot = new ConfigurationBuilder()
                    .AddXmlFile(filePath, false)
                    .Build()
                ;

            return this;
        }

        public override IEnumerable<KeyValuePair<string, string>> GetSettings()
        {
            try
            {
                return _configurationRoot.AsEnumerable()
                    .Where(pair => !string.IsNullOrEmpty(pair.Value))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to get configuration settings. {ex.Message}");
                return Enumerable.Empty<KeyValuePair<string, string>>();
            }
        }
    }
}