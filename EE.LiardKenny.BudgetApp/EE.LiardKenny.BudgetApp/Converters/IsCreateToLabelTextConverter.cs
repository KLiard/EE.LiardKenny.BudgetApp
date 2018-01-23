using EE.LiardKenny.BudgetApp.Resources;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.Converters
{
    public class IsCreateToLabelTextConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isCreate = (bool)value;

            if (isCreate)
            {
                return Texts.AddTransaction;
            }
            return Texts.EditTransaction;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
