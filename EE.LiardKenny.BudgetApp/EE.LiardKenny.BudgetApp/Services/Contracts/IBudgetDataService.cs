using EE.LiardKenny.BudgetApp.Models;
using System;
using System.Collections.Generic;

namespace EE.LiardKenny.BudgetApp.Services.Contracts
{
    public interface IBudgetDataService
    {
        IEnumerable<CashFlow> GetTransactions(DateTime dateFrom, DateTime dateTo);

        bool SaveTransaction(CashFlow cashFlow);

        void DeleteTransaction(int id);

        IEnumerable<Category> GetCategories();

        bool SaveCategory(Category category);

        void DeleteCategory(int id);
    }
}
