using System.Threading.Tasks;

namespace Formatter
{
    public interface IFormatter
    {
        Task WriteToFile(string filePath);
    }
}