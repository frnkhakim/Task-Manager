using Microsoft.Extensions.Logging;
using Task_Manager.Data.Database;
using Task_Manager.Data.Repositories;
using Task_Manager.Interfaces;
using System.IO;
using Task_Manager.Services;

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


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
