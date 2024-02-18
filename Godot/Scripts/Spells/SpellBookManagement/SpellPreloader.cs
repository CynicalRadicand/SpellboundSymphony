using Godot;

public partial class SpellPreloader : Node
{
    private static string SPELL_CONFIG_PATH = "res://Config/AbilityInfo/Player/";

    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static PlayerAbilityInfo GetPlayerAbilityInfo(string filename)
    {
        return PlayerAbilityInfo.Deserialize(SPELL_CONFIG_PATH + filename);
        //AbilityInfo.Deserialize(jsonString);
    }
}