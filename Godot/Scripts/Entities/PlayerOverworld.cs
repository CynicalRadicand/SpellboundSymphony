using Godot;
using System;

public partial class PlayerOverworld : CharacterBody2D
{
	Vector2 velocity = Vector2.Zero;

    public float maxSpeed = 150.0f;
    public float jumpForce = -200.0f;
    public float accel = 800.0f;

    public float maxFall = 500f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	double jumpHoldTime = 0.2;
	double localHoldTime = 0;

	Vector2 direction;

    protected AnimationTree animation;
	AnimationNodeStateMachinePlayback animationPlayback;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

        animation = GetNode<AnimationTree>("AnimationTree");
        animationPlayback = (AnimationNodeStateMachinePlayback) animation.Get("parameters/playback");
        GetNode<AnimationTree>("AnimationTree").Active = true;
    }


    public override void _PhysicsProcess(double delta)
    {
        velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += gravity * (float)delta;
        }


        if (velocity.Y > maxFall)
        {
            velocity.Y = maxFall;
        }

        Jump();
        localHoldTime -= delta;

        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if (direction != Vector2.Zero)
        {
            velocity.X = (float) Mathf.MoveToward(Velocity.X, direction.X * maxSpeed, accel * delta);
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, maxSpeed);
        }

        Velocity = velocity;
        MoveAndSlide();

        UpdateAnimation();
    }

	private void Jump()
	{

        if (Input.IsActionJustPressed("MoveUp") && IsOnFloor())
        {
            velocity.Y = jumpForce;
            localHoldTime = jumpHoldTime;
            animationPlayback.Travel("Jump");
        }
        else if (localHoldTime > 0)
        {
            if (Input.IsActionPressed("MoveUp"))
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

        if (IsOnFloor())
        {
            animation.Set("parameters/conditions/grounded", true);
            animation.Set("parameters/conditions/airborne", false);
        }
        else
        {
            animation.Set("parameters/conditions/grounded", false);
            animation.Set("parameters/conditions/airborne", true);
        }

        if (direction.X != 0)
		{
            animation.Set("parameters/Idle/blend_position", direction.X);
            animation.Set("parameters/Run/blend_position", direction.X);
            animation.Set("parameters/Jump/blend_position", direction.X);
            animation.Set("parameters/Fall/blend_position", direction.X);
        }

    }
}
