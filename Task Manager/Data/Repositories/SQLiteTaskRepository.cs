using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Data.Database;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Data.Repositories
{
    public class SQLiteTaskRepository : ITaskRepository
    {
        private readonly AppDatabase _database;

        public SQLiteTaskRepository(AppDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(TaskItem task)
        {
            await _database.InitializeAsync();
            await _database.Connection.InsertAsync(task);
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllAsync()
        {
            await _database.InitializeAsync();
            return await _database
                .Connection
                .Table<TaskItem>()
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            await _database.InitializeAsync();
            return await _database
                .Connection
                .Table<TaskItem>()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            await _database.InitializeAsync();
            await _database.Connection.UpdateAsync(task);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _database.InitializeAsync();
            await _database
                .Connection
                .DeleteAsync<TaskItem>(id);
        }
    }
}
