using Godot;
using System;
using System.IO;
using FileAccess = Godot.FileAccess; // To avoid confusion with System.IO.FileAccess

public partial class DataPreloader : Node
{
    private static string ABILITY_CONFIG_PATH = "res://Config/Ability/";
    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static Ability GetAbilityConfig(string filename)
    {
        FileAccess file = FileAccess.Open(ABILITY_CONFIG_PATH + filename, FileAccess.ModeFlags.Read);

        if (file == null)
        {
            GD.PrintErr("Cannot find ability config file: " + filename);
            return null;
        }

        string jsonString = file.GetAsText();
        file.Close();

        GD.Print(jsonString);

        // TODO: more descriptive errors for when a field is invalid -- custom deserializers?

        return Ability.Deserialize(jsonString);
    }
}