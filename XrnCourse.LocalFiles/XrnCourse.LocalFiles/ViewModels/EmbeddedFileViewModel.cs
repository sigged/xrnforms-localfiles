using FreshMvvm;
using Xamarin.Forms;
using System.Windows.Input;
using System.Reflection;
using System.IO;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class EmbeddedFileViewModel : FreshBasePageModel
    {
        private string _fileContents;

        public string FileContents
        {
            get => _fileContents;
            set {
                _fileContents = value;
                RaisePropertyChanged(nameof(FileContents));
            }
        }

        public ICommand ClearContentsCommand => new Command(
            () => {
                FileContents = null;
            }
        );

        public ICommand LoadFileCommand => new Command(
            () => {
                var assembly = typeof(EmbeddedFileViewModel).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("XrnCourse.LocalFiles.EmbeddedFiles.translations.txt");
                using (var reader = new StreamReader(stream))
                {
                    FileContents = reader.ReadToEnd();
                }
            }
        );


    }
}
