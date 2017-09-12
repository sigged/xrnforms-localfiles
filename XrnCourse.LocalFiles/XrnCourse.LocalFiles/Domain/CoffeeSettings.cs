using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrnCourse.LocalFiles.Domain
{
    public class CoffeeSettings
    {
        public string CoffeeName { get; set; }
        public bool HasSugar { get; set; }
        public int MilkAmount { get; set; }
        public TimeSpan BrewTime { get; set; }
    }
}
