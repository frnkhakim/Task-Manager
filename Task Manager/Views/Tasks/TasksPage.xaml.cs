using Task_Manager.ViewModels;

namespace Task_Manager.Views.Tasks;


public partial class TasksPage : ContentPage
{
	public TasksPage(TasksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}