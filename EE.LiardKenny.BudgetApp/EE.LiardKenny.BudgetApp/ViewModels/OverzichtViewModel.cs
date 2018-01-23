using EE.LiardKenny.BudgetApp.Helpers;
using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using FreshMvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.ViewModels
{
    public class OverzichtViewModel
        : FreshBasePageModel
    {
        private readonly IBudgetDataService _budgetDataService;
        private readonly ICalculatorService _calculatorService;

        private DateTime _dateFrom;

        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set
            {
                _dateFrom = value;
                RaisePropertyChanged();
                UpdateBudgetAmountDisplays();
            }
        }

        private DateTime _dateTo;

        public DateTime DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value;
                RaisePropertyChanged();
                UpdateBudgetAmountDisplays();
            }
        }

        public decimal Income { get { return CalculateInAndOutcome(true); } }

        public decimal Outcome { get { return CalculateInAndOutcome(false); } }

        public decimal Total { get { return Income - Outcome; } }

        private ObservableCollection<CashFlow> _transactions;

        public ObservableCollection<CashFlow> Transactions
        {
            get { return _transactions; }
            set
            {
                _transactions = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ViewDetailCommand => new Command<CashFlow>(
            async (CashFlow cashFlow) =>
            {
                await CoreMethods.PushPageModel<DetailViewModel>(cashFlow);
            });

        public OverzichtViewModel(IBudgetDataService budgetDataService, ICalculatorService calculatorService)
        {
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today;

            _budgetDataService = budgetDataService;
            _calculatorService = calculatorService;
        }

        private decimal CalculateInAndOutcome(bool isIncome)
        {
            Transactions = _budgetDataService.Get(DateFrom, DateTo).ToObservableCollection();

            return _calculatorService.CalculateTotal(Transactions, isIncome);
        }

        private void UpdateBudgetAmountDisplays()
        {
            RaisePropertyChanged(nameof(Income));
            RaisePropertyChanged(nameof(Outcome));
            RaisePropertyChanged(nameof(Total));
        }
    }
}
