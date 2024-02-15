using Godot;
using System;

public partial class PlayerOverworld : Node2D
{
	Vector2 velocity = Vector2.Zero;
	int maxRun = 100;
	int runAccel = 800;
	int maxFall = 160;
	int gravity = 1000;
	int jumpForce = -160;
	double jumpHoldTime = 0.2;
	double localHoldTime = 0;

	bool grounded = true;

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

		bool jump = Input.IsActionPressed("MoveUp");
		grounded = GlobalPosition.Y >= 160;

		if (jump && grounded) {
			velocity.Y = jumpForce;
			localHoldTime = jumpHoldTime;
		} else if (localHoldTime > 0) { 
			if (jump)
			{
				velocity.Y = jumpForce;
			} else
			{
				localHoldTime = 0;
			}
		}

		localHoldTime -= delta;

        velocity.X = Mathf.MoveToward(velocity.X, maxRun * direction, runAccel * (float)delta);

        velocity.Y = Mathf.MoveToward(velocity.Y, maxFall, gravity * (float)delta);

        GlobalPosition += new Vector2(velocity.X * (float)delta, velocity.Y * (float)delta);

		if (GlobalPosition.Y >= 160)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, 160);
		}

		UpdateAnimation(direction);

	}

	private void UpdateAnimation(float direction)
	{
		if(velocity.X == 0)
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
