using MAUIClient.DataService;
using MauiClient.Pages;

namespace MauiClient
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
            //builder.Services.AddSingleton<IToDoService, ToDoService>();
            builder.Services.AddHttpClient<IToDoService, ToDoService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageToDoPage>();

            return builder.Build();
        }
    }
}