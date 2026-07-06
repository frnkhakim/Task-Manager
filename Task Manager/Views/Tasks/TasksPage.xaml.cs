using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Task_Manager.Interfaces;
using Task_Manager.Models;
using Task_Manager.Services;
using static Android.Util.EventLogTags;

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