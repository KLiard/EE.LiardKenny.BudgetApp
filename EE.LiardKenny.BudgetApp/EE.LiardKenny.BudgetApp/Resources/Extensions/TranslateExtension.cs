using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EE.LiardKenny.BudgetApp.Resources.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension
        : IMarkupExtension
    {
        const string _resourceId = "EE.LiardKenny.BudgetApp.Resources.Texts";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            ResourceManager resourceManager = new ResourceManager(_resourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
