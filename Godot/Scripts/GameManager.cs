using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Handles the game flow, such as preloading data, saving data, and switching scenes.
/// 
/// Uses singletone autoloading (https://docs.godotengine.org/en/stable/tutorials/scripting/singletons_autoload.html)
/// </summary>
public partial class GameManager : Node
{
    public Node currentScene;

    public override void _Ready()
    {
        // Test loading


        string enemy = "OngoAndBongo";
        List<string> abilities = new List<string>
        {
            "b-and-o",
            "brothers-brunch",
            "ongos-onslaught"
        };

        foreach (string ability in abilities)
        {
            GD.Print(DataPreloader.GetAbilityConfig($"{enemy}/{ability}.json"));
        }



        // SetFirstScene();
    }

    public static void ChangeScene(string scene)
    {

    }

    private void SetFirstScene()
    {
        Viewport root = GetTree().Root;

        // Set current scene to the first listed in the root node
        currentScene = root.GetChild(root.GetChildCount() - 1);
    }
}