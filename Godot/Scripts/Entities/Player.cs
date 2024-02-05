using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Player : Entity
{
    private List<AbilityInfo> moveSet;

    // Pass the signal on the first beat
    private AbilityInfo storedAbility = null;

    [Signal] public delegate void PlayerAbilityEventHandler(AbilityInfo ability);

    public override void _Ready()
    {
        conductor.Beat += CountDown;
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
            EmitSignal(SignalName.PlayerAbility, storedAbility);
            storedAbility = null;
        }
        else
        {
            EmitSignal(SignalName.PlayerAbility, null);
        }
        
    }
}
