using System;
using System.IO;
using EE.LiardKenny.BudgetApp.Factories.Contracts;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(EE.LiardKenny.BudgetApp.iOS.Factories.SQLiteConnectionFactory))]
namespace EE.LiardKenny.BudgetApp.iOS.Factories
{
    internal class SQLiteConnectionFactory
        : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, databaseName);

            return new SQLiteConnection(
                new SQLitePlatformIOS(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false);
        }
    }
}