using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

/// <summary>
/// </summary>
public class EnemyInfo : JsonSerializable
{
    public string name { get; set; }
    public int hp { get; set; }
    public Position pos { get; set; }
    public ElementalResist eRes { get; set; }
    public override string Serialize()
    {
        throw new System.NotImplementedException();
    }
    public static AbilityInfo Deserialize(string filename)
    {
        return JsonSerializer.Deserialize<AbilityInfo>(filename);
    }
}