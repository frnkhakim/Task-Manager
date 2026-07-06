using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Interfaces
{
    public interface IDialogService
    {
        Task ShowAlertAsync(
            string title,
            string message,
            string cancel = "OK");

        Task<bool> ShowConfirmAsync(
            string title,
            string message,
            string accept = "OK",
            string cancel = "Cancel");
    }
}
