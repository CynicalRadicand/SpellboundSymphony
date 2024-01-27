using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
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

    protected static new List<string> REQUIRED_FIELDS = new() {
        nameof(chance),
        nameof(telegraph),
        nameof(telegraphPosition),
    };

    // 'new' keyword to hide base method from AbilityInfo
    public new string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
    public static new EnemyAbilityInfo Deserialize(string filename)
    {
        // TODO: range check for telegraph
        return JsonSerialisationUtils.Deserialize<EnemyAbilityInfo>(filename, REQUIRED_FIELDS.Concat(
            AbilityInfo.REQUIRED_FIELDS).ToList());
    }
}