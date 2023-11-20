using Godot;
using System;

public partial class player : RigidBody3D
{
	[Export] private float playerSpeed = 1000;
    [Export] private float jumpForce = 500;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector3 input = Vector3.Zero;
		input.X = Input.GetAxis("MoveLeft", "MoveRight");
		input.Z = Input.GetAxis("MoveUp", "MoveDown");
        ApplyCentralForce(input * playerSpeed * (float)delta);

		if (Input.IsActionJustPressed("Jump") && isOnGround())
		{
			ApplyCentralForce(Vector3.Up * jumpForce);
		}
	}

	private bool isOnGround()
	{
		var collidingBodies = GetCollidingBodies();

		foreach (Node3D body in collidingBodies)
		{
			if (body.IsInGroup("Ground"))
			{
				return true;
			}
		}
		return false;
	}
}