using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;

[assembly: Dependency(typeof(XrnCourse.LocalFiles.iOS.Services.TextfileService))]

namespace XrnCourse.LocalFiles.iOS.Services
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