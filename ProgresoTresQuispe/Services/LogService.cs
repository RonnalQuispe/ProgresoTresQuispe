namespace ProgresoTresQuispe.Services;

public static class LogService
{
    private static readonly string logFile = Path.Combine(FileSystem.AppDataDirectory, "Logs_Quispe.txt");

    public static void EscribirLog(string nombre)
    {
        string mensaje = $"Se incluyo el registro [{nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
        File.AppendAllText(logFile, mensaje + Environment.NewLine);
    }

    public static string LeerLogs()
    {
        return File.Exists(logFile) ? File.ReadAllText(logFile) : "Sin registros.";
    }
}
