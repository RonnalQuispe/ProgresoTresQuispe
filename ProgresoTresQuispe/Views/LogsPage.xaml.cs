using ProgresoTresQuispe.ViewModels;

namespace ProgresoTresQuispe.Views
{
    public partial class LogsPage : ContentPage
    {
        private LogsViewModel vm;

        public LogsPage()
        {
            InitializeComponent();
            vm = new LogsViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.CargarLogs();
        }
    }
}
