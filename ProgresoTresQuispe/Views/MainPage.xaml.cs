using ProgresoTresQuispe.ViewModels;

namespace ProgresoTresQuispe.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new MainViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.CargarVehiculos();
        }
    }
}
