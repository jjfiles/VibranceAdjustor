# VibranceAdjustor
## A C# utility to toggle NVIDIA Digital Vibrance values based on open applications

Detects if user defined application is currently running, and changes the digital vibrance of the selected display using NvAPIWrapper(). 

If the application is not detected, it sets the digital vibrance of the selected display to the user defined normal value.

Optionally it can launch another user defined application during this process. 

To change these options edit/create `userSettings.json`

## Download

Grab the latest build from [Releases](https://github.com/jjfiles/VibranceAdjustor/releases). It's a single self-contained `VibranceAdjustor.exe` (no .NET install needed) plus a default `userSettings.json`. Requires Windows and an NVIDIA GPU.

## Build from source

Requires the .NET SDK (6.0 or newer).

```sh
dotnet build -c Release
# or a single self-contained exe:
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o out
```

## userSettings.json

Template
```json
{
  "Application": {
    // Name of the application to check for 
    //(do not include .exe)
    "Name": "" 
  },
  "Vibrance": {
    // Desired value to change vibrance to
    // Value from 0-100
    "Max": ,
    // Desired default value to change back to if application is not detected
    // Value from 0-100
    "Normal": 
  },
  "Secondary": {
    // Name of application to open if main application is detected
    // (do not include .exe)
    "Name": "",
    // Path to application
    "Folder": "",
    // Toggle if secondary application should be launched
    // true or false
    "Enable": 
  },
  "Monitor": {
    // Index of the monitor to change values on. ranges from 0 to 1 less than the number of monitors attachted to the GPU
    // 0 is typically the primary display
    "Number": 
  }
}
```

Example
```json
{
  "Application": {
    "Name": "VALORANT"
  },
  "Vibrance": {
    "Max": 100,
    "Normal": 50
  },
  "Secondary": {
    "Name": "obs64",
    "Folder": "B:/obs-studio/bin//64bit",
    "Enable": true
  },
  "Monitor": {
    "Number": 0
  }
}
```