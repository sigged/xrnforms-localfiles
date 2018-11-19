using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class SaveAndLoadViewModel : FreshBasePageModel
    {
        private readonly ITextfileService _fileService;

        public SaveAndLoadViewModel(ITextfileService fileservice)
        {
            _fileService = fileservice;
        }

        private string _fileContents;

        public string FileContents
        {
            get => _fileContents;
            set
            {
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
            async () => {
                FileContents = await _fileService.LoadText("mysavedfile.txt");
            }
        );

        public ICommand SaveFileCommand => new Command(
            async () => {
                await _fileService.SaveText("mysavedfile.txt", FileContents);
            }
        );

    }
}
