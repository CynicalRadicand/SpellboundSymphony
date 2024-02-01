using Godot;
using System;

public partial class AbilityFactory : Node2D
{
	[Export] private Node2D projectileSpawner;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GenerateAbility(AbilityInfo ability, string target) {
		//TODO: Damage Calculation
		GD.Print("GENERATING ABILITY");
		if (ResourceLoader.Exists("res://Assets/Projectiles/" + ability.name + ".tscn"))
		{
			SpawnProjectile(ability.name, 0, target);
			GD.Print("PROJECTILE");
		}
        else
        {
            //TODO: change melee hitbox damage
        }
    }

	private void SpawnProjectile(string name, int damage, string target)
	{
        var scene = GD.Load<PackedScene>("res://Assets/Projectiles/" + name + ".tscn");
        Projectile projectile = (Projectile)scene.Instantiate();
		projectile.SetParams(damage, target);
		GetTree().CurrentScene.AddChild(projectile);
		projectile.GlobalPosition = projectileSpawner.GlobalPosition;
    }
}
