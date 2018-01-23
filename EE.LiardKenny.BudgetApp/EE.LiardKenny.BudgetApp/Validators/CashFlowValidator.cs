using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Resources;
using FluentValidation;

namespace EE.LiardKenny.BudgetApp.Validators
{
    public class CashFlowValidator
        : AbstractValidator<CashFlow>
    {
        public CashFlowValidator()
        {
            RuleFor(cashFlow => cashFlow.Amount)
                .NotEmpty()
                .WithMessage(Texts.NotEmptyErrorMessage)
                .GreaterThanOrEqualTo(cashFlow => 0m)
                .WithMessage(Texts.NotNegativeErrorMessage);
        }
    }
}
