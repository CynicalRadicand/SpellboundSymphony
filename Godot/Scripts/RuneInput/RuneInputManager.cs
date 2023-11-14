using Godot;
using System;

public partial class RuneInputManager : Node
{
	[Export] private NodePath storePresenterPath;
	RuneStorePresenter storePresenter;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		storePresenter = GetNode<RuneStorePresenter>(storePresenterPath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("RuneAir"))
		{
			storePresenter.AddRune(new Rune(Elements.AIR, "A"));
		}
		if (Input.IsActionJustPressed("RuneFire"))
		{
			storePresenter.AddRune(new Rune(Elements.FIRE, "F"));
		}
		if (Input.IsActionJustPressed("RuneEarth"))
		{
			storePresenter.AddRune(new Rune(Elements.EARTH, "E"));
		}
		if (Input.IsActionJustPressed("RuneWater"))
		{
			storePresenter.AddRune(new Rune(Elements.WATER, "W"));
		}
	}
}
