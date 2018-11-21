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
        
        private string _coffeeName;
        public string CoffeeName
        {
            get => _coffeeName;
            set
            {
                _coffeeName = value;
                RaisePropertyChanged(nameof(CoffeeName));
            }
        }

        private bool _hasSugar;
        public bool HasSugar
        {
            get => _hasSugar;
            set
            {
                _hasSugar = value;
                RaisePropertyChanged(nameof(HasSugar));
            }
        }

        private int _milkAmount;
        public int MilkAmount
        {
            get => _milkAmount;
            set
            {
                _milkAmount = value;
                RaisePropertyChanged(nameof(MilkAmount));
            }
        }

        private TimeSpan _brewTime;
        public TimeSpan BrewTime
        {
            get => _brewTime;
            set
            {
                _brewTime = value;
                RaisePropertyChanged(nameof(BrewTime));
            }
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
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

                        CoffeeName = settings.CoffeeName;
                        HasSugar = settings.HasSugar;
                        MilkAmount = settings.MilkAmount;
                        BrewTime = settings.BrewTime;
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
                    CoffeeName = CoffeeName,
                    HasSugar = HasSugar,
                    MilkAmount = _milkAmount,
                    BrewTime = BrewTime
                };
                
                //saving settings to XML file
                var serializer = new XmlSerializer(typeof(CoffeeSettings));
                string settingsAsXml;
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
