using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace HardwareInfoViewer.Views
{
    public partial class CPUView : UserControl
    {
        private MainViewModel vm;

        public CPUView(MainViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;

            var lineStroke = new SolidColorBrush(Color.FromRgb(0, 255, 136));
            var lineFill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 136)); 

            CpuChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Usage %",
                    Values = vm.CpuValues,
                    Stroke = lineStroke,
                    Fill = lineFill,
                    PointForeground = lineStroke
                }
            };

            CpuChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Temperature (\u00b0C)",
                    Values = vm.CpuTempValues,
                    Stroke = lineStroke,
                    Fill = lineFill,
                    PointForeground = lineStroke
                }
            };

            CpuChart3.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Power (W)",
                    Values = vm.CpuPowerValues,
                    Stroke = lineStroke,
                    Fill = lineFill,
                    PointForeground = lineStroke
                }
            };


            CpuChart1.DataTooltip = TooltipHelper.CreateDefaultTooltip();
            CpuChart2.DataTooltip = TooltipHelper.CreateDefaultTooltip();
            CpuChart3.DataTooltip = TooltipHelper.CreateDefaultTooltip();
        }
    }
}