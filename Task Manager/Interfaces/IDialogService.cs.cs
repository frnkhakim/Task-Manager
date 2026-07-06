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
    }
}
