using Godot;
using System;

public partial class HitBox : Area2D
{

    protected int damage = 0;
    protected string target;
    
	// Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		BodyEntered += Collision;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void SetParams(int damage, string target)
    {
        this.damage = damage;
        this.target = target;
    }

    protected void Collision(Node2D body)
	{
        //TODO: send damage request
        if (body.IsInGroup(target))
        {
            Entity entity = (Entity)body;
            entity.Damage(damage);
        }
    }
}
