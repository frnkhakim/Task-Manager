using Microsoft.Extensions.Logging;
using System.IO;
using Task_Manager.Data.Database;
using Task_Manager.Data.Repositories;
using Task_Manager.Interfaces;
using Task_Manager.Services;
using Task_Manager.ViewModels;
using Task_Manager.Views.Tasks;

namespace Task_Manager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<AppDatabase>(serviceProvider =>
            {
                var databasePath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "taskmanager.db");

                var database = new AppDatabase(databasePath);

                database.InitializeAsync().GetAwaiter().GetResult();

                return database;
            });
            builder.Services.AddSingleton<ITaskRepository, SQLiteTaskRepository>();
            builder.Services.AddTransient<TaskService>();
            builder.Services.AddTransient<TasksViewModel>();
            builder.Services.AddTransient<TasksPage>();
            builder.Services.AddSingleton<IDialogService, MauiDialogService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
