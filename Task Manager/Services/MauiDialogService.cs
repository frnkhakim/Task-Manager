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

        public async Task<bool> ShowConfirmAsync(
            string title,
            string message,
            string accept = "OK",
            string cancel = "Cancel")
        {
            if (Application.Current?.Windows.FirstOrDefault()?.Page is Page page)
            {
                return await page.DisplayAlert(title, message, accept, cancel);
            }

            return false;
        }
    }
}
