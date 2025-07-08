using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ProgresoTresQuispe.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> logs = new();

        public LogsViewModel()
        {
            CargarLogs();
        }

        public void CargarLogs()
        {
            Logs.Clear();

            string logFile = Path.Combine(FileSystem.AppDataDirectory, "Logs_Quispe.txt");

            if (File.Exists(logFile))
            {
                var lineas = File.ReadAllLines(logFile);
                foreach (var linea in lineas)
                {
                    Logs.Add(linea);
                }
            }
            else
            {
                Logs.Add("No hay registros de log aún.");
            }
        }
    }
}
