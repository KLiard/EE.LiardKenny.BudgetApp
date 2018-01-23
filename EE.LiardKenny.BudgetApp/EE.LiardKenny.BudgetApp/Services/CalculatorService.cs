using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EE.LiardKenny.BudgetApp.Services
{
    public class CalculatorService
        : ICalculatorService
    {
        public decimal CalculateTotal(IEnumerable<CashFlow> transactions, bool isIncome)
        {
            return transactions.Sum(t => t.IsAllowedForSum(isIncome));
        }
    }
}
