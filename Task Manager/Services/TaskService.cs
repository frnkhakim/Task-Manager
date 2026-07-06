using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            await _taskRepository.AddAsync(task);
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            await _taskRepository.DeleteAsync(id);
        }
    }
}