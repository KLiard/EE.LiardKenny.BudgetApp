using System;
using System.Globalization;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.Converters
{
    public class BoolToColorConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isIncome = (bool)value;

            if (isIncome)
            {
                return Color.Green;
            }
            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
