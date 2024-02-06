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
            TriggerAbility();
        }

    }

    private void TriggerAbility()
    {
        if (storedAbility != null)
        {
            factory.GenerateAbility(storedAbility, "Enemy");

            //animation.Travel(storedAbility.name);

            storedAbility = null;
        }
        else
        {
            // animation.Travel("Fizzle");
        }
    }
}
