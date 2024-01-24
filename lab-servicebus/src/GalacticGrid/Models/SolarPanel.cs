using System.Text.Json.Serialization;

namespace GalacticGrid.Models;

public class SolarPanel
{
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }
    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; set; } = Guid.NewGuid().ToString();
}