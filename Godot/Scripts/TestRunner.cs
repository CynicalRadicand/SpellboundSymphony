using System.Collections.Generic;
using Godot;

public class TestRunner
{
    public static void RunTests()
    {
        // Test loading

        Test_AbilityLoading();
        Test_EnemyAbilityLoading();
        //Test_EnemyLoading();
    }
    private static void Test_AbilityLoading()
    {
        List<string> abilities = new()
        {
            "lightning-bolt"
        };

        foreach (string ability in abilities)
        {
            GD.Print(DataPreloader.GetAbilityInfo($"Player/Spells/{ability}.json"));
        }
    }
    private static void Test_EnemyAbilityLoading()
    {
        string enemy = "OngoAndBongo";
        List<string> abilities = new()
        {
            "b-and-o",
            "brothers-brunch",
            "ongos-onslaught"
        };

        foreach (string ability in abilities)
        {
            GD.Print(DataPreloader.GetEnemyAbilityInfo($"{enemy}/{ability}.json"));
        }
    }

    /**private void Test_EnemyLoading()
    {
        GD.Print(DataPreloader.GetEnemyInfo("ongo-and-bongo.json"));
    }*/
}