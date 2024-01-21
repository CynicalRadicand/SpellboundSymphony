using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Ability : JsonSerializable
{
    public string name { get; set; }
    // public AbilityType type { get; set; }
    // public string description { get; set; }
    public int chance { get; set; } = 1;
    public int damage { get; set; } = 0;
    public int heal { get; set; } = 0;
    public int shield { get; set; } = 0;
    public List<StatusEffect> statusIncoming { get; set; } = new List<StatusEffect>();
    public List<StatusEffect> statusOutgoing { get; set; } = new List<StatusEffect>();
    public List<Position> target { get; set; } = new List<Position>();
    public int telegraph { get; set; } = 1;

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

        Targets: {ListToString(target)}

        - Telegraph: {telegraph}
        ";
    }

    private string ListToString<T>(List<T> list)
    {
        if (list == null)
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
        return JsonSerializer.Serialize(this);
    }
    public static Ability Deserialize(string filename)
    {
        return JsonSerializer.Deserialize<Ability>(filename);
    }
}
