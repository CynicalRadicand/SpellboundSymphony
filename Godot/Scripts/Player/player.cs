using Godot;
using Microsoft.VisualBasic;
using System;

public partial class player : RigidBody3D
{
	[Export] private float playerSpeed = 1000;
    [Export] private float jumpForce = 500;

    private Area3D interactArea;

    private bool interacting;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

        interactArea = GetNode<Area3D>("InteractArea");

        interactArea.BodyEntered += InteractEnter;
        interactArea.BodyExited += InteractExit;
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

		if (Input.IsActionJustPressed("Interact") && interacting)
		{
			GD.Print("Interacting");
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
    private void InteractEnter(Node3D body)
    {
        if (body.IsInGroup("Interactable"))
        {
            interacting = true;
        }
    }

    private void InteractExit(Node3D body)
    {
        if (body.IsInGroup("Interactable"))
        {
            interacting = false;
        }
    }

}