using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Godot;

/// <summary>
/// </summary>
public class EnemyInfo : JsonSerializable
{
    public string name { get; set; }
    public int hp { get; set; }
    public Vector2 idlePosition { get; set; }
    public ElementalResist resistanceMultipliers { get; set; }
    public override string ToString()
    {
        return $@"
        Enemy: {name}
        - HP: {hp}
        - Idle position: {idlePosition}
        
        Resistance multiplers: 
        - Air: {resistanceMultipliers.air}
        - Fire: {resistanceMultipliers.fire}
        - Earth: {resistanceMultipliers.earth}
        - Water: {resistanceMultipliers.water}
        ";
    }
    public override string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
    public static EnemyInfo Deserialize(string filename)
    {
        return JsonSerializer.Deserialize<EnemyInfo>(filename);
    }
}