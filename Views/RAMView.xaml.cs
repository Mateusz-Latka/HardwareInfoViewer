using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace HardwareInfoViewer.Views
{
    public partial class RAMView : UserControl
    {
        private MainViewModel vm;

        public RAMView(MainViewModel viewModel)
        {
            InitializeComponent();
            var lineStroke = new SolidColorBrush(Color.FromRgb(0, 255, 136));
            var lineFill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 136));

            RamChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.RamValues, Title= "Used RAM (MB)",Stroke = lineStroke, Fill = lineFill } };

            RamChart1.DataTooltip = TooltipHelper.CreateDefaultTooltip();
        }

    }
}