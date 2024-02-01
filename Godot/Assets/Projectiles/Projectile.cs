using Godot;
using System;

public partial class Projectile : Area2D
{
    [Export] private int speed = 1000;
    [Export] private VisibleOnScreenNotifier2D notifier;
    private int damage = 0;
    private string target;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        BodyEntered += Collide;
        notifier.ScreenExited += Destroy;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Left.Rotated(Rotation);
        GlobalPosition += speed * direction * (float)delta;
    }

    public void SetParams(int damage, string target)
    {
        this.damage = damage;
        this.target = target;
    }

    public void Collide(Node2D body)
    {
        if (body.IsInGroup(target))
        {
            //body.Damage(damage);
        }
    }

    public void Destroy()
    {
        QueueFree();
    }

}