using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        public ICommand OpenEmbeddedFilePageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<EmbeddedFileViewModel>();
            }
        );

        public ICommand OpenSaveAndLoadPageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<SaveAndLoadViewModel>();
            }
        );

        public ICommand OpenPluginPageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<PluginExampleViewModel>();
            }
        );
    }
}
