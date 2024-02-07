using System.Collections.Generic;
using System.ComponentModel;
using Godot;
using System;

public abstract partial class Entity : Node2D
{
    [Export] public string name;
    [Export] public int maxHp;
    [Export] protected int hp;
    [Export] public int shield;

    public List<StatusEffect> status;

    public Vector2 defaultPosition;

    [Export] protected Conductor conductor;

    protected AnimationNodeStateMachinePlayback animation;


    protected AbilityFactory factory;

    protected ProgressBar hpBar;

    public override void _Ready()
    {
        defaultPosition = Position;
    }

    public void Damage(int value)
    {
        hp -= value - shield;
        shield -= value;

        animation.Travel("Hurt");

        updateHP();
    }

    public void Recover(int value)
    {

    }

    public void Shield(int value)
    {

    }

    public void updateHP()
    {
        if (hpBar != null)
        {
            hpBar.Value = hp;

            if (hp >= maxHp)
            {
                hpBar.Visible = false;
            }
            else
            {
                hpBar.Visible = true;
            }
        }
    }
}
