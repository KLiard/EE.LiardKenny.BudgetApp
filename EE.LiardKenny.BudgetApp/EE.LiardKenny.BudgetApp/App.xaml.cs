using EE.LiardKenny.BudgetApp.IOC;
using EE.LiardKenny.BudgetApp.ViewModels;
using FreshMvvm;

using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIocConfig.Init();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<OverzichtViewModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
