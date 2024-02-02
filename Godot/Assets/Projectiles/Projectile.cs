using Godot;
using System;

public partial class Projectile : HitBox
{
    [Export] private int speed = 1000;
    [Export] private VisibleOnScreenNotifier2D notifier;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");

        notifier.ScreenExited += Destroy;

        // Connect BodyEntered signal from HitBox
        BodyEntered += Collision;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Left.Rotated(Rotation);
        GlobalPosition += speed * direction * (float)delta;
    }

    public void Destroy()
    {
        QueueFree();
    }

}