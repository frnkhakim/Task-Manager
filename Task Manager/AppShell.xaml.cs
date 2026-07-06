namespace Task_Manager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Update theme icon after initialization
            Dispatcher.Dispatch(() => UpdateThemeIcon());
        }

        private void OnThemeToggleClicked(object sender, EventArgs e)
        {
            // Toggle theme
            if (Application.Current != null && sender is Button button)
            {
                if (Application.Current.RequestedTheme == AppTheme.Dark)
                {
                    Application.Current.UserAppTheme = AppTheme.Light;
                    button.Text = "🌙";
                }
                else
                {
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    button.Text = "☀️";
                }
            }
        }

        private void UpdateThemeIcon()
        {
            if (Application.Current != null && ThemeToggleButton != null)
            {
                ThemeToggleButton.Text = Application.Current.RequestedTheme == AppTheme.Dark
                    ? "☀️"
                    : "🌙";
            }
        }
    }
}
