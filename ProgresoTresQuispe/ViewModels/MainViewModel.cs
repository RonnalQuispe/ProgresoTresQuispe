using CommunityToolkit.Mvvm.ComponentModel;
using ProgresoTresQuispe.Models;
using System.Collections.ObjectModel;

namespace ProgresoTresQuispe.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Vehiculo> vehiculos = new();

        public MainViewModel()
        {
            CargarVehiculos();
        }

        public void CargarVehiculos()
        {
            Vehiculos.Clear();
            var lista = App.VehiculoRepo.GetAllVehiculos();
            foreach (var vehiculo in lista)
            {
                Vehiculos.Add(vehiculo);
            }
        }
    }
}
