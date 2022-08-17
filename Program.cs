using System.Diagnostics;
using System.Text.Json;
using NvAPIWrapper;
using NvAPIWrapper.Display;

namespace VibranceAdjustor;

internal class Program
{
    private static void Main()
    {
        // TODO: readme
        // TODO: userSettings.json example
        // TODO: test
        // TODO: release
        NVIDIA.Initialize();
        Settings settings = LoadSettings();
        var displays = Display.GetDisplays();
        var mainDisplay = displays[0];
        if (Process.GetProcessesByName(settings.Application.Name).Length > 0)
        {
            Console.WriteLine($"{settings.Application.Name} detected");
            mainDisplay.DigitalVibranceControl.CurrentLevel = 100;
            Console.WriteLine($"Vibrance set to {settings.Vibrance.Max}");
            
            if (Process.GetProcessesByName("obs64").Length == 0 && settings.OBS.Enable)
            {
                Console.WriteLine("Starting OBS");
                ProcessStartInfo si = new ProcessStartInfo(Path.Combine(settings.OBS.Folder, settings.OBS.Name)) {WorkingDirectory = $"{settings.OBS.Folder}"};
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

