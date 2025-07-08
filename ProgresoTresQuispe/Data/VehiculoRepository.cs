using SQLite;
using ProgresoTresQuispe.Models;

namespace ProgresoTresQuispe.Data;


public class VehiculoRepository
{
    string _dbPath;

    private SQLiteConnection conn;

    public string StatusMessage { get; set; }
    

    public VehiculoRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Vehiculo>();
    }

    public void AddVehiculo(string marca, string modelo, int anio, string placa)
    {
        int result = 0;
        try
        {
            Init();

            if (anio < 1990 || anio > DateTime.Now.Year)
                throw new Exception("El año debe estar entre 1990 y el actual.");

            result = conn.Insert(new Vehiculo
            {
                Marca = marca,
                Modelo = modelo,
                AnioFabricacion = anio,
                Placa = placa
            });

            StatusMessage = $"Se inserto correctamente: {result} fila(s)";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Vehiculo> GetAllVehiculos()
    {
        try
        {
            Init();
            return conn.Table<Vehiculo>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al recuperar datos: {ex.Message}";
            return new List<Vehiculo>();
        }
    }
}
