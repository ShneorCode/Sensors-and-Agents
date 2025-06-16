public class Sensor
{
    public string Type { get; }

    public Sensor(string type)
    {
        Type = type;
    }

    public bool Activate(string weakness)
    {
        return Type == weakness;
    }
}
