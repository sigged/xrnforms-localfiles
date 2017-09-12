using FreshMvvm;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class SaveAndLoadViewModel : FreshBasePageModel
    {
            
        public SaveAndLoadViewModel()
        {
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
            () => {
            
            }
        );

        public ICommand SaveFileCommand => new Command(
            () => {

            }
        );
    }
}
