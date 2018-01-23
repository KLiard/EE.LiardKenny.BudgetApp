using EE.LiardKenny.BudgetApp.Factories.Contracts;
using EE.LiardKenny.BudgetApp.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace EE.LiardKenny.BudgetApp.SQLite.Base
{
    public abstract class SQLiteServiceBase
    {
        protected readonly SQLiteConnection connection;

        public SQLiteServiceBase()
        {
            var connectionFactory = DependencyService.Get<ISQLiteConnectionFactory>();
            connection = connectionFactory.CreateConnection("budgetdata.db3");

            connection.CreateTable<Category>();
            connection.CreateTable<CashFlow>();
        }
    }
}
