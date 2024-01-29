using Godot;
using System;

public partial class CombatManager : Node
{
    [Signal] public delegate void PlayerDamageEventHandler(double damage);
    [Signal] public delegate void EnemyDamageEventHandler(double damage);

    [Export] private Player player;
    [Export] private Enemy enemy;

    [Export] private Entity playerStat;
    [Export] private Entity enemyStat;

    private bool playerReady = false;
    private bool enemyReady = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        player.PlayerAbility += ProcessPlayerAbility;
        enemy.EnemyAbility += ProcessEnemyAbility;
    }

	private void ProcessPlayerAbility(AbilityInfo ability)
    {
        if(ability != null)
        {
            //(accuracy * combo * buff * debuff * target * baseDmg)
        }

        playerReady = true;
        ProcessCombat();
    }

    private void ProcessEnemyAbility(EnemyAbilityInfo ability)
    {
        if (ability != null)
        {
            //(buff * debuff * target * baseDmg)
        }

        enemyReady = true;
        ProcessCombat();
    }

    //TODO: create helper functions for damage calculation

    private void ProcessCombat()
    {
        //Combat priority: shield > damage (check if dead before moving on) > heal
        //TODO: make the actions based on beat count (maybe)?
    }
}
