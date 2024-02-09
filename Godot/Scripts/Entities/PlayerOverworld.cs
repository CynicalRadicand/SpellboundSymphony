using Godot;
using System;

public partial class PlayerOverworld : Node2D
{
	Vector2 velocity = Vector2.Zero;
	int maxRun = 100;
	int runAccel = 800;

    protected AnimationTree animation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

        animation = GetNode<AnimationTree>("AnimationTree");
        GetNode<AnimationTree>("AnimationTree").Active = true;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		float direction = Input.GetActionStrength("MoveRight") - Input.GetActionStrength("MoveLeft");

        velocity.X = Mathf.MoveToward(velocity.X, maxRun * direction, runAccel * (float)delta);

		GlobalPosition += new Vector2(velocity.X * (float)delta, 0);

		UpdateAnimation(direction);
	}

	private void UpdateAnimation(float direction)
	{
		if(velocity == Vector2.Zero)
		{
			animation.Set("parameters/conditions/idle", true);
			animation.Set("parameters/conditions/moving", false);
        }
		else
		{
            animation.Set("parameters/conditions/idle", false);
            animation.Set("parameters/conditions/moving", true);
        }

		if (direction != 0)
		{
            animation.Set("parameters/Idle/blend_position", direction);
            animation.Set("parameters/Run/blend_position", direction);
        }
		
    }
}
