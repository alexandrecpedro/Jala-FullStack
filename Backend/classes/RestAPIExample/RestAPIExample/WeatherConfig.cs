namespace RestAPIExample;

public class WeatherConfig
{
    public List<string> Summary { get; set; } = new();
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
}