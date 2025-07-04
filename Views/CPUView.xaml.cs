using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace HardwareInfoViewer.Views
{
    public partial class CPUView : UserControl
    {
        private MainViewModel vm;

        public CPUView(MainViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;

            CpuChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Usage %",
                    Values = vm.CpuValues
                }
            };

            CpuChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Temperature (\u00b0C)",
                    Values = vm.CpuTempValues
                }
            };

            CpuChart3.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Power (W)",
                    Values = vm.CpuPowerValues
                }
            };
        }
    }
}