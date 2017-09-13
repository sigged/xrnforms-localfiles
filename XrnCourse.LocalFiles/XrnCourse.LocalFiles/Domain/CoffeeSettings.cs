using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XrnCourse.LocalFiles.Domain
{
    public class CoffeeSettings
    {
        public string CoffeeName { get; set; }
        public bool HasSugar { get; set; }
        public int MilkAmount { get; set; }

        [XmlIgnore] //don't serialize this, XMLSerializer doesn't understand it
        public TimeSpan BrewTime { get; set; }

        //helps serializing the TimeSpan to XML
        public string BrewTimeAsString
        {
            get {
                return BrewTime.ToString("hhmm");
            }
            set {
                BrewTime = TimeSpan.ParseExact(value, "hhmm", CultureInfo.InvariantCulture);
            }
        }
    }
}
