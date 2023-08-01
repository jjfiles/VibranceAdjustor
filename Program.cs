using System.Diagnostics;
using System.Text.Json;
using NvAPIWrapper;
using NvAPIWrapper.Display;

namespace VibranceAdjustor;

internal class Program
{
    private static void Main()
    {
        // TODO: release
        NVIDIA.Initialize();
        Settings settings = LoadSettings();
        var displays = Display.GetDisplays();
        var mainDisplay = displays[settings.Monitor.Number];
        if (Process.GetProcessesByName(settings.Application.Name).Length > 0)
        {
            Console.WriteLine($"{settings.Application.Name} detected");
            mainDisplay.DigitalVibranceControl.CurrentLevel = 100;
            Console.WriteLine($"Vibrance set to {settings.Vibrance.Max}");
            
            if (Process.GetProcessesByName(settings.Secondary.Name).Length == 0 && settings.Secondary.Enable)
            {
                Console.WriteLine($"Starting {settings.Secondary.Name}");
                ProcessStartInfo si = new ProcessStartInfo(Path.Combine(settings.Secondary.Folder, settings.Secondary.Name)) {WorkingDirectory = $"{settings.Secondary.Folder}"};
                Process.Start(si);
            }
        }
        else
        {
            Console.WriteLine($"{settings.Application.Name} not detected");
            mainDisplay.DigitalVibranceControl.CurrentLevel = settings.Vibrance.Normal;
            Console.WriteLine($"Setting vibrance to {settings.Vibrance.Normal}");
        }
    }

    private static Settings LoadSettings()
    {
        string text = File.ReadAllText(@"userSettings.json");
        return JsonSerializer.Deserialize<Settings>(text);
        
    }
}

