using FreshMvvm;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Services;
using XrnCourse.LocalFiles.ViewModels;

namespace XrnCourse.LocalFiles
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //register dependencies
            FreshIOC.Container.Register<ITextfileService>(DependencyService.Get<ITextfileService>());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
