using EE.LiardKenny.BudgetApp.Models;
using System.Collections.Generic;

namespace EE.LiardKenny.BudgetApp.Services.Contracts
{
    public interface ICalculatorService
    {
        decimal CalculateTotal(IEnumerable<CashFlow> transactions, bool isIncome);
    }
}
