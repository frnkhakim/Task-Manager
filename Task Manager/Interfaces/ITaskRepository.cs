using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface ITaskRepository
    {
        Task<IReadOnlyList<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(Guid id);

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(Guid id);
    }
}
