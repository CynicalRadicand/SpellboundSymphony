using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class PlayerAbilityInfo : AbilityInfo
{
    public RuneSequence runeSequence { get; set; } = null;

    protected static new List<string> REQUIRED_FIELDS = new() {
        nameof(runeSequence)
    };
    protected static List<IFieldValidator> FIELD_VALIDATORS = new() {
        new FieldValidator<List<int>>(nameof(runeSequence), x => x.Count == 4, "Has 4 elements")
    };

    public static new PlayerAbilityInfo Deserialize(string filename)
    {
        PlayerAbilityInfo ability = JsonSerialisationUtils.Deserialize<PlayerAbilityInfo>(filename, REQUIRED_FIELDS.Concat(
            AbilityInfo.REQUIRED_FIELDS).ToList());

        return ability;
    }
}