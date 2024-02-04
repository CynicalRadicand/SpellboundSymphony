using System.Collections.Generic;
using System.ComponentModel;
using Godot;
using System;

public partial class Entity : Node2D
{
    [Export] public string name;
    [Export] public int hp;
    [Export] public int shield;
    public List<StatusEffect> status;

    public Vector2 defaultPosition;

    [Export] protected Conductor conductor;

    [Export] protected AnimationNodeStateMachinePlayback animation;

    public override void _Ready()
    {
        defaultPosition = Position;
    }

    public void Damage(int value)
    {

    }

    public void Recover(int value)
    {

    }

    public void Shield(int value)
    {

    }
}
