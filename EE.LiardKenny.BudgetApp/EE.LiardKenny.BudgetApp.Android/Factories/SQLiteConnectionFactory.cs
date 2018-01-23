using System.IO;
using EE.LiardKenny.BudgetApp.Factories.Contracts;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(EE.LiardKenny.BudgetApp.Droid.Factories.SQLiteConnectionFactory))]
namespace EE.LiardKenny.BudgetApp.Droid.Factories
{
    internal class SQLiteConnectionFactory
        : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, databaseName);

            return new SQLiteConnection(
                new SQLitePlatformAndroid(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false);
        }
    }
}