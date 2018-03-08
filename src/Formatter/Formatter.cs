using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Formatter
{
    public abstract class Formatter : IFormatter
    {
        public async Task WriteToFile(string filePath)
        {
            var settings = GetSettings();

            using (var file = File.CreateText(filePath))
            {
                foreach (var setting in settings)
                {
                    await file.WriteLineAsync($"{setting.Key},{setting.Value}");
                }
            }
        }

        public abstract IEnumerable<KeyValuePair<string, string>> GetSettings();
    }
}