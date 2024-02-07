using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Player : Entity
{
    private List<AbilityInfo> moveSet;

    [Signal] public delegate void PlayerAbilityEventHandler(AbilityInfo ability);

    private AbilityInfo storedAbility = null;



    public override void _Ready()
    {
        conductor.Beat += CountDown;

        animation = (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");
        GetNode<AnimationTree>("AnimationTree").Active = true;

        factory = GetNode<AbilityFactory>("AbilityFactory");

        hpBar = GetNode<ProgressBar>("HpBar");
        hpBar.MaxValue = maxHp;
        hp = maxHp;
        updateHP();
    }

    public void SetAbility(AbilityInfo ability)
    {
        //animation.Travel("Telegraph");
        storedAbility = ability;
    }

    private void CountDown(int beatNum, bool casting)
    {

        if (beatNum == 1 && casting)
        {
            if (storedAbility != null)
            {
                TriggerAbility();
            }
            else
            {
                //animation.Travel("Fizzle");
            }
        }

    }

    private void TriggerAbility()
    {
        //TODO: Refactor into entity
        factory.GenerateAbility(storedAbility, "Enemy");

        //animation.Travel(storedAbility.name);

        storedAbility = null;

    }
}