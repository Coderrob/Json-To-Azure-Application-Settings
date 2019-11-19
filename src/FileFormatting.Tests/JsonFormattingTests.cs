using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace FileFormatting.Tests
{
    public class JsonFormattingTests
    {
        private readonly JsonFormatting _formatting;

        public JsonFormattingTests()
        {
            var logger = new Mock<ILogger<JsonFormatting>>();
            _formatting = new JsonFormatting(logger.Object);
        }

        //[Fact]
        public async Task LoadJsonSuccessfully()
        {
            await _formatting
                .Load("./TestData/sample.json")
                .WriteToFile("c:\\devspace\\v300-json.csv");
        }
    }
}