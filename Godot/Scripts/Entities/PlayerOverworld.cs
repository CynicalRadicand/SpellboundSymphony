using Godot;
using System;

public partial class PlayerOverworld : Node2D
{
	Vector2 velocity = Vector2.Zero;
	int maxRun = 100;
	int runAccel = 800;
	int maxFall = 200;
	int gravity = 1000;
	int jumpForce = -200;
	double jumpHoldTime = 0.2;
	double localHoldTime = 0;

	bool grounded = true;
	float direction;

    protected AnimationTree animation;
	AnimationNodeStateMachinePlayback animationPlayback;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

        animation = GetNode<AnimationTree>("AnimationTree");
        animationPlayback = (AnimationNodeStateMachinePlayback) animation.Get("parameters/playback");
        GetNode<AnimationTree>("AnimationTree").Active = true;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		direction = Input.GetActionStrength("MoveRight") - Input.GetActionStrength("MoveLeft");

        Jump();
        localHoldTime -= delta;

        velocity.X = Mathf.MoveToward(velocity.X, maxRun * direction, runAccel * (float)delta);
        velocity.Y = Mathf.MoveToward(velocity.Y, maxFall, gravity * (float)delta);


        GlobalPosition += new Vector2(velocity.X * (float)delta, velocity.Y * (float)delta);

        // Fake Floor, remove later
		if (GlobalPosition.Y >= 200)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, 200);
			grounded = true;
		}
		else
		{
            grounded = false;
        }

		UpdateAnimation();

	}

	private void Jump()
	{
        bool jump = Input.IsActionPressed("MoveUp");

        if (jump && grounded)
        {
            velocity.Y = jumpForce;
            localHoldTime = jumpHoldTime;
            animationPlayback.Travel("Jump");
        }
        else if (localHoldTime > 0)
        {
            if (jump)
            {
                velocity.Y = jumpForce;
            }
            else
            {
                localHoldTime = 0;
            }
        }

    }

	private void UpdateAnimation()
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

        if (grounded)
        {
            animation.Set("parameters/conditions/grounded", true);
            animation.Set("parameters/conditions/airborne", false);
        }
        else
        {
            animation.Set("parameters/conditions/grounded", false);
            animation.Set("parameters/conditions/airborne", true);
        }

        if (direction != 0)
		{
            animation.Set("parameters/Idle/blend_position", direction);
            animation.Set("parameters/Run/blend_position", direction);
            animation.Set("parameters/Jump/blend_position", direction);
            animation.Set("parameters/Fall/blend_position", direction);
        }

    }
}
