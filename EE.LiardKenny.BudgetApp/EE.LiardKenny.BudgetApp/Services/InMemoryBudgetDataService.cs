using EE.LiardKenny.BudgetApp.Models;
using EE.LiardKenny.BudgetApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.LiardKenny.BudgetApp.Services
{
    public class InMemoryBudgetDataService
        : IBudgetDataService
    {
        private readonly IEnumerable<CashFlow> _inMemoryDatabase;

        public InMemoryBudgetDataService()
        {
            _inMemoryDatabase = new List<CashFlow>
            {
                new CashFlow
                {
                    ID = 1,
                    DateOfTransaction = DateTime.Today,
                    Category = new Category
                    {
                        ID = 1,
                        Name = "Eten"
                    },
                    IsIncome = false,
                    Amount = 2.5m,
                    Description = "Lekker broodje",
                    Image = "Selfie met broodje"
                },
                new CashFlow
                {
                    ID = 2,
                    DateOfTransaction = DateTime.Today,
                    Category = new Category
                    {
                        ID = 2,
                        Name = "Geluk",
                        Description = "Inkomsten die onverwacht komen",
                        IsIncome = true
                    },
                    IsIncome = true,
                    Amount = 10m,
                    Description = "10 euro gevonden op straat!",
                    Image = "Briefje op straat"
                },
                new CashFlow
                {
                    ID = 3,
                    DateOfTransaction = DateTime.Today.AddDays(1),
                    Category = new Category
                    {
                        ID = 1,
                        Name = "Eten"
                    },
                    IsIncome = false,
                    Amount = 15m,
                    Description = "Afhaalchinees met een Martini",
                    Image = ""
                }
            };
        }

        public IEnumerable<CashFlow> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _inMemoryDatabase.Where(d => d.DateOfTransaction >= dateFrom && d.DateOfTransaction <= dateTo);
        }
    }
}
