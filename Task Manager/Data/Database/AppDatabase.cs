using SQLite;
using Task_Manager.Models;

namespace Task_Manager.Data.Database
{
    public class AppDatabase
    {
        public SQLiteAsyncConnection Connection { get; }

        public AppDatabase(string databasePath)
        {
            Connection = new SQLiteAsyncConnection(databasePath);
        }

        public async Task InitializeAsync()
        {
            await Connection.CreateTableAsync<TaskItem>();
            await Connection.CreateTableAsync<Category>();
        }
    }
}