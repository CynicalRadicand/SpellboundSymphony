using Godot;
using System;

public partial class TimingManager : Node
{
    [Export] private NodePath conductorPath;

    [Signal] public delegate void TimingInputEventHandler(InputDTO inputDTO);

    public override void _Ready()
    {
        var conductor = GetNode<Conductor>(conductorPath);
        conductor.ConductorInput += CheckTiming;
    }

    private void CheckTiming(InputDTO inputDTO, double inputSec, double beatSec)
    {
        double timeDifferenceMs = (inputSec - beatSec) * 1000;
        GD.Print("Time Difference: " + timeDifferenceMs);

        //TODO: Time difference to animate slider for accuracy visualisation
        switch (timeDifferenceMs)
        {
            case <= 10 and >= -10:
                GD.Print("PERFECT");
                inputDTO.Accuracy = Accuracy.PERFECT;
                break;
            case <= 25 and > +-25:
                GD.Print("GREAT");
                inputDTO.Accuracy = Accuracy.GREAT;
                break;
            case <= 50 and >= -50:
                GD.Print("GOOD");
                inputDTO.Accuracy = Accuracy.GOOD;
                break;
            case <= 75 and >= -75:
                GD.Print("OK");
                inputDTO.Accuracy = Accuracy.OK;
                break;
            case <= 100 and >= -100:
                GD.Print("POOR");
                inputDTO.Accuracy = Accuracy.POOR;
                break;
            default:
                GD.Print("MISS");
                inputDTO.KeyAction = Elements.MISS;
                inputDTO.Accuracy = Accuracy.MISS;
                break;
        }

        EmitSignal(SignalName.TimingInput, inputDTO);   
    }
}
