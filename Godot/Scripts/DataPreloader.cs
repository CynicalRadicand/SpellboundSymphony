using Godot;
using System;
using System.IO;
using FileAccess = Godot.FileAccess; // To avoid confusion with System.IO.FileAccess

public partial class DataPreloader : Node
{
    /// <summary>
    /// Use this method to load up the values for abilities before entering combat.
    /// </summary>
    /// <param name="filename"></param>
    public static Ability GetAbilityConfig(string filePath)
    {
        FileAccess file = FileAccess.Open("user://" + filePath, FileAccess.ModeFlags.Read);
        string jsonString = file.GetAsText();

        return Ability.Deserialize(jsonString);
    }
}