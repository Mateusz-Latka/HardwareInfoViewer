using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace HardwareInfoViewer.Views
{
    public partial class GPUView : UserControl
    {
        private MainViewModel vm;

        public GPUView(MainViewModel viewModel)
        {
            InitializeComponent();

            GpuChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuValues, Title = "GPU Usage %" } };
            GpuChart2.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuTempValues, Title="GPU Temperature (\u00b0C)" } };
            GpuChart3.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuFanValues, Title= "GPU Fan Speed (RPM)" } };
        }

    }
}