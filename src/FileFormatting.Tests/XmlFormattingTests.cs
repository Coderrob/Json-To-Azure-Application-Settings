using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace FileFormatting.Tests
{
    public class XmlFormattingTests
    {
        private readonly XmlFormatting _formatting;

        public XmlFormattingTests()
        {
            var logger = new Mock<ILogger<XmlFormatting>>();
            _formatting = new XmlFormatting(logger.Object);
        }

        //[Fact]
        public async Task LoadXmlSuccessfully()
        {
            await _formatting
                .Load("./TestData/sample.v300.xml")
                .WriteToFile("c:\\devspace\\v300.csv");
        }
    }
}