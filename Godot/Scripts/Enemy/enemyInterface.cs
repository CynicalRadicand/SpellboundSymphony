using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract partial class enemyInterface : Node
{
    private string name;
    private int hp;
    private ElementalResist eRes;
    private List<Ability> abilities;
    private int ratioTotal;

    public override void _Ready()
    {
        //TODO: load stats from JSON

        foreach (Ability ability in abilities)
        {
            ratioTotal += ability.chance;
        }
        
    }

    public void AbilitySelect()
    {
        Random random = new Random();
        int rand = random.Next(0, ratioTotal);

        int abilityID = 0;

        foreach (Ability ability in abilities)
        {
            if ((rand -= ability.chance) < 0)
            {
                TriggerAbility(abilityID);
                break;
            }
            else
            {
                abilityID++;
            }
        }
    }

    public void TriggerAbility(int abilityID)
    {

    }
}
