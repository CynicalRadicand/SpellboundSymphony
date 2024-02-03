using Godot;
using System;
using System.Collections.Generic;

public partial class Enemy : Entity
{
    private List<EnemyAbilityInfo> moveSet;
    private int ratioTotal = 0;
    private EnemyAbilityInfo storedAbility = null;
    private AbilityFactory factory;

    private int delay = 0;
    private int telegraph = 0;

    

    public override void _Ready()
    {
        //TODO: load stats from JSON

        // Dummy Moveset
        EnemyAbilityInfo attack = new EnemyAbilityInfo();
        attack.name = "Attack";
        attack.telegraph = 6;
        //attack.chance = 0;

        EnemyAbilityInfo projectile = new EnemyAbilityInfo();
        projectile.name = "Projectile";
        projectile.telegraph = 4;
        //projectile.chance = 0;

        EnemyAbilityInfo spew = new EnemyAbilityInfo();
        spew.name = "Spew";
        spew.telegraph = 2;

        moveSet = new List<EnemyAbilityInfo>
        {
            attack,
            projectile,
            spew
        };



        foreach (EnemyAbilityInfo ability in moveSet)
        {
            ratioTotal += ability.chance;
        }

        conductor.Beat += CountDown;

        animation = (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");
        GetNode<AnimationTree>("AnimationTree").Active = true;

        factory = GetNode<AbilityFactory>("AbilityFactory");
    }

    private void CountDown(int beatNum, bool casting)
    {
        //TODO: Test logic with dummy variables
        if (delay <= 0)
        {
            telegraph--;
        }

        delay--;

        if (delay == 0 && telegraph > 0)
        {
            TriggerTelegraph();
        }
        
        if (delay <= 0 && telegraph == 0)
        {
            TriggerAbility();
        }

        if (beatNum == 1 && !casting && storedAbility == null)
        {
            AbilitySelect();
        }
        

    }

    private void AbilitySelect()
    {
        Random random = new Random();
        int rand = random.Next(0, ratioTotal);

        int abilityID = 0;

        foreach (EnemyAbilityInfo ability in moveSet)
        {
            if ((rand -= ability.chance) < 0)
            {
                storedAbility = moveSet[abilityID];
                SetTelegraph(storedAbility);
                break;
            }
            else
            {
                abilityID++;
            }
        }
    }

    private void SetTelegraph(EnemyAbilityInfo storedAbility)
    {
        // Telegraph should always be between 1-8 beats
        telegraph = storedAbility.telegraph + 4;
        delay = 12 - telegraph;

        // edge case where the telegraph should begin on the same beat
        if (telegraph == 12) { TriggerTelegraph(); }
    }

    private void TriggerTelegraph()
    {
        animation.Travel(storedAbility.name + "Telegraph");
    }

    private void TriggerAbility()
    {
        factory.GenerateAbility(storedAbility, "Player");

        animation.Travel(storedAbility.name);

        storedAbility = null;
    }
}
