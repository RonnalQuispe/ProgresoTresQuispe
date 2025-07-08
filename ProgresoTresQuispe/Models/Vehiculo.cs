using SQLite;

namespace ProgresoTresQuispe.Models;

[Table("vehiculos")]
public class Vehiculo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Marca { get; set; }

    [MaxLength(100)]
    public string Modelo { get; set; }

    public int AnioFabricacion { get; set; }

    [MaxLength(10), Unique]
    public string Placa { get; set; }
}
