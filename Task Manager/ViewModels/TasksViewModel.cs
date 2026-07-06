using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Task_Manager.Models;
using Task_Manager.Services;

namespace Task_Manager.ViewModels
{
    public partial class TasksViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;

        public ObservableCollection<TaskItem> Tasks { get; } = new();

        public TasksViewModel(TaskService taskService)
        {
            _taskService = taskService;

            Title = "Tasks";
        }

        [RelayCommand]
        private async Task LoadTasksAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                Tasks.Clear();

                var tasks = await _taskService.GetAllTasksAsync();

                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}