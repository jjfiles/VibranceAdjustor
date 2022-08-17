using System.Diagnostics;
using NvAPIWrapper;
using NvAPIWrapper.Display;

namespace VibranceAdjustor;

internal class Program
{
    private static void Main()
    {
        NVIDIA.Initialize();
        var displays = Display.GetDisplays();
        var mainDisplay = displays[0];
        // TODO: setting for EXE name
        if (Process.GetProcessesByName("VALORANT").Length > 0)
        {
            // TODO: replace with exe name
            Console.WriteLine("VALORANT detected");
            // TODO: replace max value
            mainDisplay.DigitalVibranceControl.CurrentLevel = 100;
            Console.WriteLine("Vibrance set");
            
            // TODO option for opening obs
            if (Process.GetProcessesByName("obs64").Length == 0)
            {
                Console.WriteLine("Starting OBS");
                // TODO: add path from settings
                ProcessStartInfo si = new ProcessStartInfo(@"B:\obs-studio\bin\64bit\obs64") {WorkingDirectory = @"B:\obs-studio\bin\64bit"};
                Process.Start(si);
            }
        }
        else
        {
            // TODO: replace with app name
            Console.WriteLine("VALORANT not detected");
            // TODO: let user set default level
            mainDisplay.DigitalVibranceControl.CurrentLevel = mainDisplay.DigitalVibranceControl.DefaultLevel;
            Console.WriteLine("Setting vibrance to default");
        }
    }
}

