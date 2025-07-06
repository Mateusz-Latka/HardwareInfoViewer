using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace HardwareInfoViewer.Views
{
    public partial class DiskView : UserControl
    {
        private MainViewModel vm;

        public DiskView(MainViewModel viewModel)
        {
            InitializeComponent();
            var lineStroke = new SolidColorBrush(Color.FromRgb(0, 255, 136));
            var lineFill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 136));

            DiskChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.DiskValues, Title = "Disk Usage %", Stroke = lineStroke, Fill = lineFill,} };

            DiskChart1.DataTooltip = TooltipHelper.CreateDefaultTooltip();
        }
    }
}