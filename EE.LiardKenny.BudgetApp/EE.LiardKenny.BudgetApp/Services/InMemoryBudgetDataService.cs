using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EE.LiardKenny.BudgetApp.Services
{
    public class InMemoryBudgetDataService
        : IBudgetDataService
    {
        private static IList<CashFlow> _inMemoryDatabase;
        private static IList<Category> _inMemoryCategoryDatabase;

        public InMemoryBudgetDataService()
        {
            _inMemoryCategoryDatabase = new List<Category>
            {
                new Category
                    {
                        ID = 1,
                        Name = "Eten"
                    },
                new Category
                    {
                        ID = 2,
                        Name = "Geluk",
                        Description = "Inkomsten die onverwacht komen",
                        IsIncome = true
                    },
                new Category
                    {
                        ID = 1,
                        Name = "Eten"
                    }
            };

            _inMemoryDatabase = new List<CashFlow>
            {
                new CashFlow
                {
                    ID = 1,
                    DateOfTransaction = DateTime.Today,
                    Category = _inMemoryCategoryDatabase.FirstOrDefault(c => c.ID == 1),
                    IsIncome = false,
                    Amount = 2.5m,
                    Description = "Lekker broodje",
                    Image = "Selfie met broodje"
                },
                new CashFlow
                {
                    ID = 2,
                    DateOfTransaction = DateTime.Today,
                    Category = _inMemoryCategoryDatabase.FirstOrDefault(c => c.ID == 2),
                    IsIncome = true,
                    Amount = 10m,
                    Description = "10 euro gevonden op straat!",
                    Image = "Briefje op straat"
                },
                new CashFlow
                {
                    ID = 3,
                    DateOfTransaction = DateTime.Today.AddDays(1),
                    Category = _inMemoryCategoryDatabase.FirstOrDefault(c => c.ID == 3),
                    IsIncome = false,
                    Amount = 15m,
                    Description = "Afhaalchinees met een Martini",
                    Image = ""
                }
            };
        }

        public void DeleteCategory(int id)
        {
            var category = _inMemoryCategoryDatabase.FirstOrDefault(c => c.ID == id);

            _inMemoryCategoryDatabase.Remove(category);
        }

        public void DeleteTransaction(int id)
        {
            var cashFlow = _inMemoryDatabase.FirstOrDefault(c => c.ID == id);

            _inMemoryDatabase.Remove(cashFlow);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _inMemoryCategoryDatabase.ToList();
        }

        public IEnumerable<CashFlow> GetTransactions(DateTime dateFrom, DateTime dateTo)
        {
            return _inMemoryDatabase.Where(d => d.DateOfTransaction >= dateFrom && d.DateOfTransaction <= dateTo);
        }

        public bool SaveCategory(Category category)
        {
            _inMemoryCategoryDatabase.Add(category);

            return true;
        }

        public bool SaveTransaction(CashFlow cashFlow)
        {
            _inMemoryDatabase.Add(cashFlow);

            return true;
        }
    }
}
