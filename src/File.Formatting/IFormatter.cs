using System.Threading.Tasks;

namespace FileFormatting
{
    public interface IFormatter
    {
        Task WriteToFile(string filePath);
    }
}