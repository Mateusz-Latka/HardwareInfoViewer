using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace HardwareInfoViewer.Views
{
    public partial class RAMView : UserControl
    {
        private MainViewModel vm;

        public RAMView(MainViewModel viewModel)
        {
            InitializeComponent();

            RamChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.RamValues, Title= "Used RAM (MB)" } };
        }

    }
}