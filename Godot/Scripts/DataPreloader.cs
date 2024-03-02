using Godot;

public partial class DataPreloader : Node
{
    private static string ABILITY_CONFIG_PATH = "res://Config/AbilityInfo";

    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static AbilityInfo GetAbilityInfo(string filename)
    {
        // TODO: more descriptive errors for when a field is invalid -- custom deserializers?

        return null;
        //AbilityInfo.Deserialize(jsonString);
    }

    public static EnemyAbilityInfo GetEnemyAbilityInfo(string enemy, string filename)
    {
        return EnemyAbilityInfo.Deserialize($"{ABILITY_CONFIG_PATH}/{enemy}/{filename}.json");
    }

    // public static EnemyInfo GetEnemyInfo(string filename)
    // {
    //     string jsonString = GetFileAsString(ENEMY_CONFIG_PATH + filename);
    //     GD.Print(jsonString);

    //     return EnemyInfo.Deserialize(jsonString);
    // }
}