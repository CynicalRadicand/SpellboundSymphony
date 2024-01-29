using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Enemy : Entity
{
    private List<EnemyAbilityInfo> moveSet;
    private int ratioTotal = 0;
    private EnemyAbilityInfo storedAbility = null;

    private int delay = 0;
    private int telegraph = 0;


    [Export] private NodePath conductorPath;

    [Signal] public delegate void EnemyAbilityEventHandler(EnemyAbilityInfo storedability);


    public override void _Ready()
    {
        //TODO: load stats from JSON

        // Dummy Moveset
        EnemyAbilityInfo ability1 = new EnemyAbilityInfo();
        ability1.name = "Telegraph 5";
        ability1.telegraph = 1;

        EnemyAbilityInfo ability2 = new EnemyAbilityInfo();
        ability2.name = "Telegraph 8";
        ability2.telegraph = 4;

        EnemyAbilityInfo ability3 = new EnemyAbilityInfo();
        ability3.name = "Telegraph 10";
        ability3.telegraph = 6;

        EnemyAbilityInfo ability4 = new EnemyAbilityInfo();
        ability4.name = "Telegraph 12";
        ability4.telegraph = 8;

        moveSet = new List<EnemyAbilityInfo>
        {
            ability1,
            ability2,
            ability3,
            ability4,
        };



        foreach (EnemyAbilityInfo ability in moveSet)
        {
            ratioTotal += ability.chance;
        }

        var conductor = GetNode<Conductor>(conductorPath);
        conductor.Beat += CountDown;

    }

    private void CountDown(int beatNum, bool casting)
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
        
        if (delay <= 0 && telegraph == 0)
        {
            TriggerAbility();
            GD.Print("CASTING ON BEAT NUM: " + beatNum);
        }
        else if (beatNum == 1 && casting)
        {
            TriggerIdle();
        }

        if (beatNum == 1 && !casting && storedAbility == null)
        {
            AbilitySelect();
        }
        

    }

    private void AbilitySelect()
    {
        Random random = new Random();
        int rand = random.Next(0, ratioTotal);

        int abilityID = 0;

        foreach (EnemyAbilityInfo ability in moveSet)
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

    private void SetTelegraph(EnemyAbilityInfo storedAbility)
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
        EmitSignal(SignalName.EnemyAbility, storedAbility);
        GD.Print("CASTING: " + storedAbility.name);

        storedAbility = null;
    }

    private void TriggerIdle()
    {
        //TODO: emit idle signal to combat manager
        EmitSignal(SignalName.EnemyAbility, null);
        GD.Print("IDLE");
    }
}
