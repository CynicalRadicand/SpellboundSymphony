using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Enemy : Node
{
    private EnemyInfo enemyInfo;
    private List<AbilityInfo> moveSet;
    private int ratioTotal = 0;
    private AbilityInfo storedAbility;

    private int delay = 0;
    private int telegraph = 0;


    [Export] private NodePath conductorPath;


    public override void _Ready()
    {
        //TODO: load stats from JSON

        // Dummy Moveset
        AbilityInfo ability1 = new AbilityInfo();
        ability1.name = "Telegraph 5";
        ability1.telegraph = 1;

        AbilityInfo ability2 = new AbilityInfo();
        ability2.name = "Telegraph 8";
        ability2.telegraph = 4;

        AbilityInfo ability3 = new AbilityInfo();
        ability3.name = "Telegraph 10";
        ability3.telegraph = 6;

        AbilityInfo ability4 = new AbilityInfo();
        ability4.name = "Telegraph 12";
        ability4.telegraph = 8;

        moveSet = new List<AbilityInfo>
        {
            ability1,
            ability2,
            ability3,
            ability4,
        };



        foreach (AbilityInfo ability in moveSet)
        {
            ratioTotal += ability.chance;
        }

        var conductor = GetNode<Conductor>(conductorPath);
        conductor.Beat += CountDown;

    }

    private void CountDown(int beatNum, bool playerCasting)
    {
        //TODO: Test logic with dummy variables
        if (delay <= 0)
        {
            telegraph--;
        }

        delay--;

        GD.Print("DELAY: " + delay + " TELEGRAPH: " + telegraph);

        if (delay == 0 && telegraph > 0)
        {
            TriggerTelegraph();
        }
        else if (delay <= 0 && telegraph == 0)
        {
            TriggerAbility();
            GD.Print("CASTING ON BEAT NUM: " + beatNum);
        }
        else if (beatNum == 1 && !playerCasting && delay < 0 && telegraph < 0)
        {
            AbilitySelect();
        }

    }

    private void AbilitySelect()
    {
        Random random = new Random();
        int rand = random.Next(0, ratioTotal);

        int abilityID = 0;

        foreach (AbilityInfo ability in moveSet)
        {
            if ((rand -= ability.chance) < 0)
            {
                storedAbility = moveSet[abilityID];
                SetTelegraph(storedAbility);
                break;
            }
            else
            {
                abilityID++;
            }
        }
    }

    private void SetTelegraph(AbilityInfo storedAbility)
    {
        // Telegraph should always be between 1-8 beats
        telegraph = storedAbility.telegraph + 4;
        delay = 12 - telegraph;

        GD.Print("STORED: " + storedAbility.name);

        // edge case where the telegraph should begin on the same beat
        if (telegraph == 12) { TriggerTelegraph(); }
    }

    private void TriggerTelegraph()
    {
        //TODO: play animation

        GD.Print("TELEGRAPHING");
    }

    private void TriggerAbility()
    {
        //TODO: emit signal to combat manager

        GD.Print("CASTING: " + storedAbility.name);
    }
}
