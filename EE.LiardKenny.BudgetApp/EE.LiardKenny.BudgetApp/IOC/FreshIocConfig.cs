using EE.LiardKenny.BudgetApp.Services;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using EE.LiardKenny.BudgetApp.Validators;
using FluentValidation;
using FreshMvvm;

namespace EE.LiardKenny.BudgetApp.IOC
{
    public static class FreshIocConfig
    {
        public static void Init()
        {
            FreshIOC.Container.Register<IBudgetDataService, InMemoryBudgetDataService>();
            FreshIOC.Container.Register<ICalculatorService, CalculatorService>();
            FreshIOC.Container.Register<IValidator, CashFlowValidator>();
        }
    }
}
