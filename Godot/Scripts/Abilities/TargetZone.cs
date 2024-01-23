using System.Text.Json.Serialization;

[JsonConverter(typeof(TwoDimensionalIntArrayJsonConverter))]
public class TargetZone
{
    public int[,] multipliers { get; set; } = new int[3, 3];
}