using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class SaveAndLoadViewModel : FreshBasePageModel
    {
        private ITextfileService fileService;

        public SaveAndLoadViewModel(ITextfileService fileservice)
        {
            fileService = fileservice;
        }

        private string fileContents;

        public string FileContents
        {
            get { return fileContents; }
            set
            {
                fileContents = value;
                this.RaisePropertyChanged(nameof(FileContents));
            }
        }

        public ICommand ClearContentsCommand => new Command(
            () => {
                FileContents = null;
            }
        );

        public ICommand LoadFileCommand => new Command(
            async () => {
                FileContents = await fileService.LoadText("mysavedfile.txt");
            }
        );

        public ICommand SaveFileCommand => new Command(
            async () => {
                await fileService.SaveText("mysavedfile.txt", FileContents);
            }
        );

    }
}
