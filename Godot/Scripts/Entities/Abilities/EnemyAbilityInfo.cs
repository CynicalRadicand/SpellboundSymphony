using Godot;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

/// <summary>
/// Stores information about player and enemy combat abilities.
/// 
/// Note: player abilities can ignore chance and telegraph.
/// </summary>
public class EnemyAbilityInfo : AbilityInfo
{
    public int chance { get; set; } = 1;
    public int telegraph { get; set; } = 1; //must be between 1-8
    public Vector2 telegraphPosition { get; set; } = Entity.DEFAULT_POSITION;
}