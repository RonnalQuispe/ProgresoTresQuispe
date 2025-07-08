
using ProgresoTresQuispe.Data;
using System.IO;
using Microsoft.Maui.Storage;


namespace ProgresoTresQuispe
{
    public partial class App : Application
    {
        public static VehiculoRepository VehiculoRepo { get; private set; }

        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "vehiculos.db");
            VehiculoRepo = new VehiculoRepository(dbPath);

            MainPage = new AppShell();
        }
    }
}
