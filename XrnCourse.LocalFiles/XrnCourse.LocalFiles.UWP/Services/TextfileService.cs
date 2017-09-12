using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;

[assembly: Dependency(typeof(XrnCourse.LocalFiles.UWP.Services.TextfileService))]

namespace XrnCourse.LocalFiles.UWP.Services
{
    internal class TextfileService : ITextfileService
    {
        public async Task SaveText(string filename, string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder
                .CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }
        public async Task<string> LoadText(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await FileIO.ReadTextAsync(sampleFile);
            return text;
        }
    }
}
