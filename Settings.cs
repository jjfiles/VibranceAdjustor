namespace VibranceAdjustor;

public class Application
{
    public string Name { get; set; }
}

public class Secondary
{
    public string Name { get; set; }
    public string Folder { get; set; }
    public bool Enable { get; set; }
}

public class Settings
{
    public Application Application { get; set; }
    public Vibrance Vibrance { get; set; }
    public Secondary Secondary { get; set; }
    public Monitor Monitor { get; set; }
}

public class Vibrance
{
    public int Max { get; set; }
    public int Normal { get; set; }
}

public class Monitor
{
    public int Number { get; set; }
}
