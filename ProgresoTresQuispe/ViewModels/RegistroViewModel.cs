using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProgresoTresQuispe.Models;
using ProgresoTresQuispe.Services; 
using ProgresoTresQuispe.Data;
using ProgresoTresQuispe;

namespace ProgresoTresQuispe.ViewModels
{
    public partial class RegistroViewModel : ObservableObject
    {
        [ObservableProperty] private string marca;
        [ObservableProperty] private string modelo;
        [ObservableProperty] private string placa;
        [ObservableProperty] private int anioFabricacion;

        public IRelayCommand GuardarCommand { get; }

        public RegistroViewModel()
        {
            GuardarCommand = new RelayCommand(async () => await GuardarAsync());
        }

        private async Task GuardarAsync()
        {
            if (anioFabricacion < 1990 || anioFabricacion > DateTime.Now.Year)
            {
                await Shell.Current.DisplayAlert("Error", "El anio debe estar entre 1990 y el actual.", "OK");
                return;
            }

            var vehiculo = new Vehiculo
            {
                Marca = Marca,
                Modelo = Modelo,
                Placa = Placa,
                AnioFabricacion = AnioFabricacion
            };

            App.VehiculoRepo.AddVehiculo(vehiculo.Marca, vehiculo.Modelo, vehiculo.AnioFabricacion, vehiculo.Placa);


            LogService.EscribirLog(Marca);

            await Shell.Current.DisplayAlert("exito", "Vehiculo registrado.", "OK");

            Marca = Modelo = Placa = string.Empty;
            AnioFabricacion = 0;
        }
    }
}
