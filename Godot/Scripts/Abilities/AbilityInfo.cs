using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Godot;

/// <summary>
/// Stores information about player and enemy combat abilities.
/// 
/// Note: player abilities can ignore chance and telegraph.
/// </summary>
public class AbilityInfo : JsonSerializable
{
    private static Vector2 DEFAULT_POSITION = new Vector2(1, 1);
    private static JsonSerializerOptions SERIALIZER_OPTIONS = new JsonSerializerOptions();

    public string name { get; set; }
    // public AbilityType type { get; set; }
    // public string description { get; set; }
    public int chance { get; set; } = 1;
    public int damage { get; set; } = 0;
    public int heal { get; set; } = 0;
    public int shield { get; set; } = 0;
    public List<StatusEffect> statusIncoming { get; set; } = new List<StatusEffect>();
    public List<StatusEffect> statusOutgoing { get; set; } = new List<StatusEffect>();
    public TargetZone targetZone { get; set; } = new TargetZone();
    public int telegraph { get; set; } = 1;
    public Vector2 telegraphPosition { get; set; } = DEFAULT_POSITION;
    public Vector2 position { get; set; } = DEFAULT_POSITION;

    public AbilityInfo()
    {
        if (SERIALIZER_OPTIONS == null)
        {
            SERIALIZER_OPTIONS.Converters.Add(new TwoDimensionalIntArrayJsonConverter());
        }
    }

    public override string ToString()
    {
        return $@"
        Ability: {name}
        - Chance: {chance}
        - Damage: {damage}
        - Heal: {heal}
        - Shield: {shield}

        Statuses:
        - Incoming: {ListToString(statusIncoming)}
        - Outgoing: {ListToString(statusOutgoing)}

        Targets:
        {targetZone}

        - Telegraph: {telegraph}
        - Telegraph position: {telegraphPosition}
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

    public override string Serialize()
    {
        return JsonSerializer.Serialize(this, SERIALIZER_OPTIONS);
    }
    public static AbilityInfo Deserialize(string filename)
    {
        return JsonSerializer.Deserialize<AbilityInfo>(filename, SERIALIZER_OPTIONS);
    }
}
