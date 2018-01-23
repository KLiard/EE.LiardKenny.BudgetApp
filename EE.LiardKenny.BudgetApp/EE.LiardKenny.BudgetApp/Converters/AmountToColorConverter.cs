using System;
using System.Globalization;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.Converters
{
    public class AmountToColorConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal amount = (decimal)value;

            if (amount < 0)
            {
                return Color.Red;
            }
            return Color.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
