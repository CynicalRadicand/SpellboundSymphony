using Godot;
using System;

public partial class CombatManager : Node
{
    [Signal] public delegate void PlayerDamageEventHandler(double damage);
    [Signal] public delegate void EnemyDamageEventHandler(double damage);

    [Export] private NodePath PlayerActionPath;
    [Export] private NodePath EnemyActionPath;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
