using System;
using System.Globalization;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.Converters
{
    public class MilkAmountToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                switch (value)
                {
                    case 0:
                        return "Black";
                    case 1:
                        return "Macchiato";
                    case 2:
                        return "Café au lait";
                    case 3:
                        return "Latté";
                    case 4:
                        return "Flat white";
                }
                return $"{value} years old";
            }

            throw new ArgumentException("value must be of type 'int'", nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
