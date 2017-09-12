using System;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;
using System.Threading.Tasks;
using System.IO;

[assembly: Dependency(typeof(XrnCourse.LocalFiles.Droid.Services.TextfileService))]

namespace XrnCourse.LocalFiles.Droid.Services
{
    public class TextfileService : ITextfileService
    {
        public async Task SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
            await Task.Delay(0);
        }
        public async Task<string> LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            await Task.Delay(0);
            return File.ReadAllText(filePath);
        }
    }
}
