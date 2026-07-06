using SQLite;
using Task_Manager.Models;

namespace Task_Manager.Data.Database
{
    public class AppDatabase
    {
        private readonly SemaphoreSlim _initLock = new(1, 1);
        private bool _initialized;

        public SQLiteAsyncConnection Connection { get; }

        public AppDatabase(string databasePath)
        {
            Connection = new SQLiteAsyncConnection(databasePath);
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
                return;

            await _initLock.WaitAsync();
            try
            {
                if (_initialized)
                    return;

                await Connection.CreateTableAsync<TaskItem>();
                await Connection.CreateTableAsync<Category>();
                _initialized = true;
            }
            finally
            {
                _initLock.Release();
            }
        }
    }
}
