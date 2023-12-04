using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract partial class enemyInterface : Node
{
    private string name;
    private int hp;
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

        foreach (Ability ability in moveSet)
        {
            ratioTotal += ability.chance;
        }

        var conductor = GetNode<Conductor>(conductorPath);
        conductor.Beat += CountDown;

    }

    private void CountDown(int beatNum, bool playerCasting)
    {
        if (delay == 0)
        {
            telegraph--;
        }

        delay--;

        if (delay == 0 && telegraph > 0)
        {
            TriggerTelegraph();
        }
        else if (delay == 0 && telegraph == 0)
        {
            TriggerAbility();
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
                storedAbility = moveSet[abilityID]
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
        telegraph = storedAbility.telegraph + 4;
        delay = 12 - telegraph;
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
