using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace HardwareInfoViewer.Views
{
    public partial class GPUView : UserControl
    {
        private MainViewModel vm;

        public GPUView(MainViewModel viewModel)
        {
            InitializeComponent();
            var lineStroke = new SolidColorBrush(Color.FromRgb(0, 255, 136));
            var lineFill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 136));

            GpuChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuValues, Title = "GPU Usage %", Stroke = lineStroke, Fill = lineFill } };
            GpuChart2.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuTempValues, Title="GPU Temperature (\u00b0C)", Stroke = lineStroke, Fill = lineFill } };
            GpuChart3.Series = new SeriesCollection { new LineSeries { Values = viewModel.GpuFanValues, Title= "GPU Fan Speed (RPM)", Stroke = lineStroke, Fill = lineFill } };

            GpuChart1.DataTooltip = TooltipHelper.CreateDefaultTooltip();
            GpuChart2.DataTooltip = TooltipHelper.CreateDefaultTooltip();
            GpuChart3.DataTooltip = TooltipHelper.CreateDefaultTooltip();
        }

    }
}