using EE.LiardKenny.BudgetApp.Services;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using FreshMvvm;

namespace EE.LiardKenny.BudgetApp.IOC
{
    public static class FreshIocConfig
    {
        public static void Init()
        {
            FreshIOC.Container.Register<IBudgetDataService, InMemoryBudgetDataService>();
            FreshIOC.Container.Register<ICalculatorService, CalculatorService>();
        }
    }
}
