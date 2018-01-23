using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using EE.LiardKenny.BudgetApp.SQLite.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EE.LiardKenny.BudgetApp.Services
{
    public class SQLiteBudgetDataService
        : SQLiteServiceBase,
        IBudgetDataService
    {
        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CashFlow> GetTransactions(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                if (connection.Table<CashFlow>().Count() > 0)
                {
                    return connection.Table<CashFlow>().Where(c => c.DateOfTransaction >= dateFrom && c.DateOfTransaction <= dateTo).ToList();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool SaveTransaction(CashFlow cashFlow)
        {
            throw new NotImplementedException();
        }
    }
}
