using HardwareInfoViewer.ViewModels;
using HardwareInfoViewer.Views;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareInfoViewer
{
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        private readonly HttpClient httpClient = new();

        public MainWindow()
        {
            InitializeComponent();
            AskServerAddressAndInitAsync();
        }

        private async void AskServerAddressAndInitAsync()
        {
            string? serverAddress = null;
            bool serverOk = false;

            while (!serverOk)
            {
                var dialog = new ServerAddressDialog();
                bool? result = dialog.ShowDialog();

                if (result != true)
                {
                    Close();
                    return;
                }

                serverAddress = dialog.ServerAddress;

                serverOk = await CheckServerHealthAsync(serverAddress);

                if (!serverOk)
                {
                    MessageBox.Show("Cannot connect to the server or server is unhealthy. Please enter a valid address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            vm = new MainViewModel(serverAddress!);
            DataContext = vm;

            MainContent.Content = new CPUView(vm);
        }

        private async Task<bool> CheckServerHealthAsync(string serverAddress)
        {
            try
            {
                var healthUrl = serverAddress.TrimEnd('/') + "/health";
                var response = await httpClient.GetAsync(healthUrl);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private void CPU_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CPUView(vm);
        }

        private void GPU_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new GPUView(vm);
        }

        private void RAM_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RAMView(vm);
        }

        private void Disk_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DiskView(vm);
        }
    }
}
