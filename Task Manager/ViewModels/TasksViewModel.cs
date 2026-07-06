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

    [RelayCommand]
    private async Task DeleteTaskAsync(TaskItem task)
    {
        if (task == null)
            return;

        var confirm = await _dialogService.ShowConfirmAsync(
            "Delete Task",
            $"Are you sure you want to delete '{task.Title}'?",
            "Yes",
            "No");

        if (confirm)
        {
            await _taskService.DeleteTaskAsync(task.Id);
            Tasks.Remove(task);
        }
    }

    [RelayCommand]
    private async Task EditTaskAsync(TaskItem task)
    {
        if (task == null)
            return;

        // For now, we'll populate the input fields with the task data
        // In a full app, you'd want a separate edit page or dialog
        TaskTitle = task.Title;
        Description = task.Description;
        DueDate = task.DueDate;
        Priority = task.Priority;

        // Remove the old task from the list
        Tasks.Remove(task);

        // Delete from database so it can be re-added with updates
        await _taskService.DeleteTaskAsync(task.Id);
    }

    public async Task ToggleTaskCompletionAsync(TaskItem task)
    {
        if (task == null)
            return;

        if (task.IsCompleted)
        {
            task.Reopen();
        }
        else
        {
            task.MarkAsCompleted();
        }

        await _taskService.UpdateTaskAsync(task);
    }
}