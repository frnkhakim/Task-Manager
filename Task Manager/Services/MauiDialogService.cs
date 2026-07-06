using Task_Manager.Interfaces;

namespace Task_Manager.Services
{
    public class MauiDialogService : IDialogService
    {
        public async Task ShowAlertAsync(
            string title,
            string message,
            string cancel = "OK")
        {
            if (Application.Current?.Windows.FirstOrDefault()?.Page is Page page)
            {
                await page.DisplayAlert(title, message, cancel);
            }
        }
    }
}