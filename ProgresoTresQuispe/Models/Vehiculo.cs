using SQLite;

namespace ProgresoTresQuispe.Models
{
    public class Vehiculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }

        public int AnioFabricacion { get; set; }

        public string Placa { get; set; }
    }
}
