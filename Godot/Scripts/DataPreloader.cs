using Godot;
using System;
using System.IO;
using FileAccess = Godot.FileAccess; // To avoid confusion with System.IO.FileAccess

public partial class DataPreloader : Node
{
    private static string ABILITY_CONFIG_PATH = "res://Config/AbilityInfo/";
    private static string ENEMY_CONFIG_PATH = "res://Config/EnemyInfo/";

    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static AbilityInfo GetAbilityInfo(string filename)
    {
        string jsonString = GetFileAsString(ABILITY_CONFIG_PATH + filename);
        GD.Print(jsonString);

        // TODO: more descriptive errors for when a field is invalid -- custom deserializers?

        return null;
            //AbilityInfo.Deserialize(jsonString);
    }

    /**
    public static EnemyInfo GetEnemyInfo(string filename)
    {
        string jsonString = GetFileAsString(ENEMY_CONFIG_PATH + filename);
        GD.Print(jsonString);

        return EnemyInfo.Deserialize(jsonString);
    }
    */

    private static string GetFileAsString(string filePath)
    {
        FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);

        if (file == null)
        {
            GD.PrintErr("Cannot find info config file: " + filePath);
            return null;
        }

        string jsonString = file.GetAsText();
        file.Close();

        return jsonString;
    }
}