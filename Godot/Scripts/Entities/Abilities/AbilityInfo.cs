using Godot;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

/// <summary>
/// Stores information about player and enemy combat abilities.
/// 
/// Note: player abilities can ignore chance and telegraph.
/// </summary>
public partial class AbilityInfo : GodotObject
{
    public string name { get; set; }
    public int damage { get; set; } = 0;
    public int heal { get; set; } = 0;
    public int shield { get; set; } = 0;
    public List<StatusEffect> statusIncoming { get; set; } = new List<StatusEffect>();
    public List<StatusEffect> statusOutgoing { get; set; } = new List<StatusEffect>();

    public override string ToString()
    {
        return $@"
        Ability: {name}
        - Damage: {damage}
        - Heal: {heal}
        - Shield: {shield}

        Statuses:
        - Incoming: {ListToString(statusIncoming)}
        - Outgoing: {ListToString(statusOutgoing)}

        ";
    }

    private string ListToString<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return "(Empty)";
        }

        string outString = "";
        foreach (var item in list)
        {
            outString += $"[{item}]";
        }
        return outString;
    }

    /*public override string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
    public static AbilityInfo Deserialize(string filename)
    {
        return JsonSerializer.Deserialize<AbilityInfo>(filename);
    }*/
}
