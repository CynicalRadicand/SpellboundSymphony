using System.Collections.Generic;
using Godot;

public partial class SpellPreloader : Node
{
    private static string SPELL_CONFIG_PATH = "res://Config/AbilityInfo/Player/Spells";

    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static PlayerAbilityInfo GetPlayerAbilityInfo(string filename)
    {
        AbilityInfo tempAbility = AbilityInfo.Deserialize($"{SPELL_CONFIG_PATH}/{filename}.json");

        // FIXME: temporary conversion until RuneSequence can be deserialised

        PlayerAbilityInfo ability = new();
        ability.name = tempAbility.name;

        ability.runeSequence = new RuneSequence(new List<Rune>()
        {
            new(Elements.AIR), new(Elements.AIR), new(Elements.AIR), new(Elements.AIR)
        });
        return ability;
        //AbilityInfo.Deserialize(jsonString);
    }
}