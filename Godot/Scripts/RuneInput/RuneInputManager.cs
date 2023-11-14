using Godot;
using System;

public partial class RuneInputManager : Node
{
    [Signal] public delegate void InputSignalEventHandler(InputDTO inputDTO);

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsAnythingPressed())
		{
            InputDTO inputDTO = new InputDTO();

            if (Input.IsActionJustPressed("RuneAir"))
            {
                inputDTO.KeyAction = Elements.AIR;
            }
            if (Input.IsActionJustPressed("RuneFire"))
            {
                inputDTO.KeyAction = Elements.FIRE;
            }
            if (Input.IsActionJustPressed("RuneEarth"))
            {
                inputDTO.KeyAction = Elements.EARTH;
            }
            if (Input.IsActionJustPressed("RuneWater"))
            {
                inputDTO.KeyAction = Elements.WATER;
            }

            EmitSignal(SignalName.InputSignal, inputDTO);
        }
		
	}
}
