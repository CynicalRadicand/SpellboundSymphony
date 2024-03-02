using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Player : Entity
{

    [Signal] public delegate void PlayerAbilityEventHandler(AbilityInfo ability);
    [Signal] public delegate void FinishInputEventHandler();
    public SpellBook spellBook;

    private AbilityInfo storedAbility = null;

    public override void _Ready()
    {
        conductor.Beat += CountDown;

        animation = (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");
        GetNode<AnimationTree>("AnimationTree").Active = true;

        factory = GetNode<AbilityFactory>("AbilityFactory");


        spellBook = new SpellBook();
        spellBook.ClearLoadout();

        List<string> abilities = new()
        {
            "lightning-bolt", "earth-pillar"
        };
        foreach (string ability in abilities)
        {
            spellBook.AddSpell(SpellPreloader.GetPlayerAbilityInfo(ability));
        }
    }

    public void SetAbility(AbilityInfo ability)
    {
        animation.Travel("Telegraph");
        GD.Print("Telegraph");
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
                animation.Travel("Fizzle");
                GD.Print("Fizzle");
            }

            EmitSignal(SignalName.FinishInput);
        }

        if (beatNum == 4 && casting)
        {
            animation.Travel("Idle");
        }

    }

    private void TriggerAbility()
    {
        //TODO: Refactor into entity
        factory.GenerateAbility(storedAbility, "Enemy");

        animation.Travel(storedAbility.name);

        // Clear ability
        storedAbility = null;

    }
}