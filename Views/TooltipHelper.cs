using LiveCharts.Wpf;
using System.Windows.Media;

namespace HardwareInfoViewer.Views;

public class TooltipHelper
{
    public static DefaultTooltip CreateDefaultTooltip()
    {
        return new DefaultTooltip
        {
            Background = new SolidColorBrush(Color.FromRgb(30, 30, 30)),
            Foreground = new SolidColorBrush(Colors.White),
            FontSize = 14
        };
    }
}