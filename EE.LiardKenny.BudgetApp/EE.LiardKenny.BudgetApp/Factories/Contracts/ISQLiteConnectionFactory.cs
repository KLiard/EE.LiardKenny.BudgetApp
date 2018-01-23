using SQLite.Net;

namespace EE.LiardKenny.BudgetApp.Factories.Contracts
{
    public interface ISQLiteConnectionFactory
    {
        SQLiteConnection CreateConnection(string databaseName);
    }
}
