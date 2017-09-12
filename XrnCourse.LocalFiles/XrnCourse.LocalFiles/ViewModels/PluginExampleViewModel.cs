using FreshMvvm;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Domain;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class PluginExampleViewModel : FreshBasePageModel
    {
        public CoffeeSettings CurrentSettings { get; set; }

        
        private string coffeeName;
        public string CoffeeName
        {
            get { return coffeeName; }
            set
            {
                coffeeName = value;
                RaisePropertyChanged(nameof(CoffeeName));
            }
        }

        private bool hasSugar;
        public bool HasSugar
        {
            get { return hasSugar; }
            set
            {
                hasSugar = value;
                RaisePropertyChanged(nameof(HasSugar));
            }
        }

        private int milkAmount;
        public int MilkAmount
        {
            get { return milkAmount; }
            set
            {
                milkAmount = value;
                RaisePropertyChanged(nameof(MilkAmount));
            }
        }

        private TimeSpan brewTime;
        public TimeSpan BrewTime
        {
            get { return brewTime; }
            set
            {
                brewTime = value;
                RaisePropertyChanged(nameof(BrewTime));
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            //todo: load settings from XML
        }


        public ICommand ResetToDefaultsCommand => new Command(
            () => {
                CoffeeName = null;
                HasSugar = false;
                MilkAmount = 0;
                BrewTime = TimeSpan.Zero;
            }
        );

        public ICommand SaveSettingsCommand => new Command(
            () => {
                var settings = new CoffeeSettings{
                    CoffeeName = this.CoffeeName,
                    HasSugar = this.HasSugar,
                    MilkAmount = this.milkAmount,
                    BrewTime = this.BrewTime
                };

                //todo: save to XML file here!
            }
        );


    }
}
