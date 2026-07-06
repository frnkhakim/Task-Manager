using Task_Manager.ViewModels;
using Task_Manager.Models.Enums;
using Task_Manager.Models;

namespace Task_Manager.Views.Tasks;

public partial class TasksPage : ContentPage
{
    private readonly TasksViewModel _viewModel;

    public TasksPage(TasksViewModel viewModel)
    {
        InitializeComponent();

        PriorityPicker.ItemsSource = Enum.GetValues<Priority>().ToList();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!_viewModel.IsBusy)
        {
            _viewModel.LoadTasksCommand.Execute(null);
        }
    }

    private async void OnTaskCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is TaskItem task)
        {
            await _viewModel.ToggleTaskCompletionAsync(task);
        }
    }
}
