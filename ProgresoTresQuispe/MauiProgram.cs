using Microsoft.Extensions.Logging;
using ProgresoTresQuispe.Data;
using System.IO;

namespace ProgresoTresQuispe
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

            
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "vehiculos.db3");

            
            builder.Services.AddSingleton<VehiculoRepository>(s =>
                ActivatorUtilities.CreateInstance<VehiculoRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();  
#endif

            return builder.Build();
        }
    }
}
