using FreshMvvm;
using PCLStorage;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Domain;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class PluginExampleViewModel : FreshBasePageModel
    {
        
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

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            //load settings from XML
            string fileName = "settings.xml";
            IFolder folder = FileSystem.Current.LocalStorage;
            ExistenceCheckResult result = await folder.CheckExistsAsync(fileName);
            if (result == ExistenceCheckResult.FileExists)
            {
                try
                {
                    IFile file = await folder.GetFileAsync(fileName);
                    string text = await file.ReadAllTextAsync();
                    using (var reader = new StringReader(text))
                    {
                        var serializer = new XmlSerializer(typeof(CoffeeSettings));
                        CoffeeSettings settings = (CoffeeSettings)serializer.Deserialize(reader);

                        this.CoffeeName = settings.CoffeeName;
                        this.HasSugar = settings.HasSugar;
                        this.MilkAmount = settings.MilkAmount;
                        this.BrewTime = settings.BrewTime;
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine($"Error reading settings: {ex.Message}");
                }
            }
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
            async () => {
                var settings = new CoffeeSettings
                {
                    CoffeeName = this.CoffeeName,
                    HasSugar = this.HasSugar,
                    MilkAmount = this.milkAmount,
                    BrewTime = this.BrewTime
                };
                
                //saving settings to XML file
                var serializer = new XmlSerializer(typeof(CoffeeSettings));
                string settingsAsXml = "";
                using (var stringWriter = new StringWriter())
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        serializer.Serialize(writer, settings);
                        settingsAsXml = stringWriter.ToString();
                    }

                IFolder folder = FileSystem.Current.LocalStorage;
                IFile file = await folder.CreateFileAsync("settings.xml", 
                    CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(settingsAsXml);
            }
        );


    }
}
