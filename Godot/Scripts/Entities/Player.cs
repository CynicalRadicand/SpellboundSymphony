using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Player : Entity
{
    private List<AbilityInfo> moveSet;

    // Pass the signal on the first beat
    [Export] private NodePath conductorPath;
    private AbilityInfo storedAbility = null;


    public override void _Ready()
    {
        var conductor = GetNode<Conductor>(conductorPath);
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
        //TODO: emit signal to combat manager
        if (storedAbility != null)
        {
            //TODO: emit signal to combat manager
            storedAbility = null;
        }
        else
        {
            //TODO: emit idle signal
        }
        
    }
}
