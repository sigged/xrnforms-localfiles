using System.Threading.Tasks;

namespace XrnCourse.LocalFiles.Services
{
    public interface ITextfileService
    {
        Task SaveText(string filename, string text);
        Task<string> LoadText(string filename);
    }
}
