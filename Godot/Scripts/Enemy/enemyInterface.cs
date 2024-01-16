using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class enemyInterface : Node
{
    private string name;
    private int hp;
    private Position pos;
    private ElementalResist eRes;
    private List<Ability> moveSet;
    private int ratioTotal = 0;
    private Ability storedAbility;

    private int delay = 0;
    private int telegraph = 0;


    [Export] private NodePath conductorPath;


    public override void _Ready()
    {
        //TODO: load stats from JSON

        // Dummy Moveset
        Ability ability1 = new Ability();
        ability1.name = "ability1";
        ability1.telegraph = 1;

        Ability ability2 = new Ability();
        ability2.name = "ability2";
        ability2.telegraph = 8;

        moveSet = new List<Ability>
        {
            ability1,
            ability2
        };



        foreach (Ability ability in moveSet)
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
            GD.Print("TELEGRAPHING");
        }
        else if (delay <= 0 && telegraph == 0)
        {
            TriggerAbility();
            GD.Print("CASTING: " + storedAbility.name);
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

        foreach (Ability ability in moveSet)
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

    private void SetTelegraph(Ability storedAbility)
    {
        // Telegraph should always be between 1-8 beats
        telegraph = storedAbility.telegraph + 4;
        delay = 12 - telegraph;
        GD.Print("STORED: " + storedAbility.name);
    }

    private void TriggerTelegraph()
    {
        //TODO: play animation
    }

    private void TriggerAbility()
    {
        //TODO: emit signal to combat manager
    }
}
