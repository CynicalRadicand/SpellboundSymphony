using System.Text.Json.Serialization;

public class TargetZone
{
    public int[,] multipliers { get; set; } = new int[3, 3];
}