using LiveCharts;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HardwareInfoViewer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ChartValues<double> CpuValues { get; set; } = new ChartValues<double>();
        public ChartValues<double> CpuTempValues { get; set; } = new ChartValues<double>();
        public ChartValues<double> CpuPowerValues { get; set; } = new ChartValues<double>();

        public ChartValues<double> GpuValues { get; set; } = new ChartValues<double>();
        public ChartValues<double> GpuTempValues { get; set; } = new ChartValues<double>();
        public ChartValues<double> GpuFanValues { get; set; } = new ChartValues<double>();

        public ChartValues<double> RamValues { get; set; } = new ChartValues<double>();
        public ChartValues<double> DiskValues { get; set; } = new ChartValues<double>();

        private readonly HttpClient httpClient = new();
        private readonly string serverAddress;

        public MainViewModel(string serverAddress)
        {
            this.serverAddress = serverAddress;
            StartMonitoring();
        }

        private void StartMonitoring()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var json = await httpClient.GetStringAsync(serverAddress + "/metrics");
                        var metrics = JsonSerializer.Deserialize<MetricsDto>(
                            json,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                        );

                        AddValue(CpuValues, metrics?.CpuUsage ?? 0);
                        OnPropertyChanged(nameof(CpuValues));

                        AddValue(CpuTempValues, metrics?.CpuTemp ?? 0);
                        OnPropertyChanged(nameof(CpuTempValues));

                        AddValue(CpuPowerValues, metrics?.CpuPower ?? 0);
                        OnPropertyChanged(nameof(CpuPowerValues));

                        AddValue(GpuValues, metrics?.GpuLoad ?? 0);
                        OnPropertyChanged(nameof(GpuValues));

                        AddValue(GpuTempValues, metrics?.GpuTemp ?? 0);
                        OnPropertyChanged(nameof(GpuTempValues));

                        AddValue(GpuFanValues, metrics?.GpuFan ?? 0);
                        OnPropertyChanged(nameof(GpuFanValues));

                        AddValue(RamValues, metrics?.RamUsage ?? 0);
                        OnPropertyChanged(nameof(RamValues));

                        AddValue(DiskValues, metrics?.DiskUsage ?? 0);
                        OnPropertyChanged(nameof(DiskValues));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error fetching metrics: {ex.Message}");
                    }

                    await Task.Delay(1000);
                }
            });
        }

        private void AddValue(ChartValues<double> series, double value)
        {
            if (series.Count > 60)
                series.RemoveAt(0);

            series.Add(value);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class MetricsDto
        {
            public float CpuUsage { get; set; }
            public float CpuTemp { get; set; }
            public float CpuPower { get; set; }
            public float GpuLoad { get; set; }
            public float GpuTemp { get; set; }
            public float GpuFan { get; set; }
            public float RamUsage { get; set; }
            public float DiskUsage { get; set; }
        }
    }
}
