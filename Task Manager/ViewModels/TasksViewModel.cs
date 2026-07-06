using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Task_Manager.Interfaces;
using Task_Manager.Models;
using Task_Manager.Models.Enums;
using Task_Manager.Services;


namespace Task_Manager.ViewModels;

public partial class TasksViewModel : BaseViewModel
{
    private readonly TaskService _taskService;
    private readonly IDialogService _dialogService;

    public ObservableCollection<TaskItem> Tasks { get; } = new();

    public TasksViewModel(
        TaskService taskService,
        IDialogService dialogService)
    {
        _taskService = taskService;
        _dialogService = dialogService;

        Title = "Tasks";
    }

    [ObservableProperty]
    private string taskTitle = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private DateTime dueDate = DateTime.Today;

    [ObservableProperty]
    private Priority priority = Priority.Medium;

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

    [RelayCommand]
    private async Task AddTaskAsync()
    {
        if (string.IsNullOrWhiteSpace(TaskTitle))
        {
            await _dialogService.ShowAlertAsync(
                "Validation",
                "Please enter a task title.");

            return;
        }

        var task = new TaskItem(TaskTitle, DueDate);

        task.UpdateDescription(Description);
        task.ChangePriority(Priority);

        await _taskService.CreateTaskAsync(task);

        Tasks.Add(task);

        TaskTitle = string.Empty;
        Description = string.Empty;
        DueDate = DateTime.Today;
        Priority = Priority.Medium;
    }
}