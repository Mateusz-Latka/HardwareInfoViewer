using HardwareInfoViewer.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace HardwareInfoViewer.Views
{
    public partial class DiskView : UserControl
    {
        private MainViewModel vm;

        public DiskView(MainViewModel viewModel)
        {
            InitializeComponent();

            DiskChart1.Series = new SeriesCollection { new LineSeries { Values = viewModel.DiskValues, Title = "Disk Usage %" } };
        }

    }
}