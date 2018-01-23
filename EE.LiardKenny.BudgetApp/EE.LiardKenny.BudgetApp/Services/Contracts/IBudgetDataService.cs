using EE.LiardKenny.BudgetApp.Models;
using System;
using System.Collections.Generic;

namespace EE.LiardKenny.BudgetApp.Services.Contracts
{
    public interface IBudgetDataService
    {
        IEnumerable<CashFlow> Get(DateTime dateFrom, DateTime dateTo);
    }
}
