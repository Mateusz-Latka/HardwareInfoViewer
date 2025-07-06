# 🖥️ HardwareInfoViewer

A WPF client application to visualize live hardware metrics fetched from [HardwareInfoServer](https://github.com/Mateusz-Latka/HardwareInfoServer).  
Displays CPU, GPU, RAM and Disk usage with interactive charts.

---

## 📋 Features

✅ Connects to a server on your LAN and fetches real-time metrics  
✅ Displays:
- CPU usage, temperature, power
- GPU load, temperature, fan speed
- RAM usage
- Disk usage

✅ Dynamic server selection — user is prompted to enter server address at startup  
✅ Beautiful LiveCharts-based graphs for each metric

---

## 💻 Program in action

Here is how the application looks in dark mode with green accent:

![HardwareInfoViewer Screenshot](https://github.com/user-attachments/assets/1520d8f3-9dc6-4fda-bb5a-ba9c5496bb56)

---

## 🧰 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (for building)
- Windows OS
- [LiveCharts](https://lvcharts.net/) 0.9.x (already included via NuGet)
- A running instance of [HardwareInfoServer](https://github.com/Mateusz-Latka/HardwareInfoServer)

---

## 🚀 Getting Started

### 📦 Installation

Clone the repository:
```bash
git clone https://github.com/your-org/HardwareInfoViewer.git
cd HardwareInfoViewer
```
Build and run the application:
```bash
dotnet build
dotnet run

