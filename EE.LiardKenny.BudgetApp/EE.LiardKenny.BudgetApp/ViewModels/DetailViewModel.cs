using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Resources;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.ViewModels
{
    public class DetailViewModel
        : FreshBasePageModel
    {
        private CashFlow _currentCashFlow;
        private readonly IValidator _validator;

        public bool IsCreate { get; set; }

        public IList<Category> Categories { get; set; }

        private DateTime _dateOfTransaction;

        public DateTime DateOfTransaction
        {
            get { return _dateOfTransaction; }
            set
            {
                _dateOfTransaction = value;
                RaisePropertyChanged();
            }
        }

        private Category _category;

        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                RaisePropertyChanged();
            }
        }

        private bool _isIncome;

        public bool IsIncome
        {
            get { return _isIncome; }
            set
            {
                _isIncome = value;
                RaisePropertyChanged();
            }
        }

        private decimal _amount;

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged();
            }
        }

        private string _amountErrorMessage;

        public string AmountErrorMessage
        {
            get { return _amountErrorMessage; }
            set
            {
                _amountErrorMessage = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(AmountErrorIsVisible));
            }
        }

        public bool AmountErrorIsVisible { get { return !string.IsNullOrWhiteSpace(AmountErrorMessage); } }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }

        private string _cashFlowDirection;

        public string CashFlowDirection
        {
            get { return _cashFlowDirection; }
            set
            {
                _cashFlowDirection = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand => new Command(
            () =>
            {
                SaveData();

                Validate(_currentCashFlow);
            });

        public ICommand SetIsIncomeCommand => new Command(
            () =>
            {
                IsIncome = !IsIncome;
                CashFlowDirection = DisplayCashFlowDirection();
                RaisePropertyChanged(nameof(CashFlow.CashFlowDirection));
            });

        public DetailViewModel(IValidator validator)
        {
            _validator = validator;

            if (Categories == null)
            {
                var category = new Category
                {
                    ID = 1,
                    Description = "Test",
                    IsIncome = true,
                    Name = "TestCategorie"
                };
                Categories = new List<Category>();
                Categories.Add(category);
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData != null)
            {
                _currentCashFlow = initData as CashFlow;
                IsCreate = false;
            }
            else
            {
                _currentCashFlow = new CashFlow();
                IsCreate = true;
            }

            LoadData();
        }

        private string DisplayCashFlowDirection()
        {
            if (IsIncome)
            {
                return Texts.Incoming;
            }
            return Texts.Outcoming;
        }

        private bool Validate(CashFlow cashFlow)
        {
            AmountErrorMessage = null;

            var validationResult = _validator.Validate(cashFlow);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(cashFlow.Amount))
                {
                    AmountErrorMessage = error.ErrorMessage;
                }
            }

            return validationResult.IsValid;
        }

        private void LoadData()
        {
            if (IsCreate)
            {
                DateOfTransaction = DateTime.Today;
                Category = Categories[0];
                IsIncome = Category.IsIncome;
            }
            else
            {
                DateOfTransaction = _currentCashFlow.DateOfTransaction;
                Category = _currentCashFlow.Category;
                IsIncome = _currentCashFlow.IsIncome;
                Amount = _currentCashFlow.Amount;
                Description = _currentCashFlow.Description;
            }

            CashFlowDirection = DisplayCashFlowDirection();
        }

        private void SaveData()
        {
            _currentCashFlow.Amount = Amount;
            _currentCashFlow.Category = Category;
            _currentCashFlow.DateOfTransaction = DateOfTransaction;
            _currentCashFlow.Description = Description;
            _currentCashFlow.IsIncome = IsIncome;
        }
    }
}
