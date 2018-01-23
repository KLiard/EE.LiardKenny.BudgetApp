using EE.LiardKenny.BudgetApp.Factories.Contracts;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(EE.LiardKenny.BudgetApp.UWP.Factories.SQLiteConnectionFactory))]
namespace EE.LiardKenny.BudgetApp.UWP.Factories
{
    internal class SQLiteConnectionFactory
        : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseName)
        {
            string path = ApplicationData.Current.LocalFolder.Path;
            path = Path.Combine(path, databaseName);

            return new SQLiteConnection(
                new SQLitePlatformWinRT(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false);
        }
    }
}
