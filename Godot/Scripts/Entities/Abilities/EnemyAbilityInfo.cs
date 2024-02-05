using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

/// <summary>
/// Stores information about player and enemy combat abilities.
/// 
/// Note: player abilities can ignore chance and telegraph.
/// </summary>
public partial class EnemyAbilityInfo : AbilityInfo
{
    public int chance { get; set; } = 1;
    public int telegraph { get; set; } = 1; //must be between 1-8
    public Vector2 telegraphPosition { get; set; } = Entity.DEFAULT_POSITION;

    protected static new List<string> REQUIRED_FIELDS = new() {
        nameof(chance),
        nameof(telegraph),
        nameof(telegraphPosition),
    };

    protected static List<IFieldValidator> FIELD_VALIDATORS = new() {
        new FieldValidator<int>(nameof(chance), x => x > 0, "Greater than 0"),
        new FieldValidator<int>(nameof(telegraph), x => x >= 1 && x <= 8, "Between 1 and 8 (inclusive)")
    };

    // 'new' keyword to hide base method from AbilityInfo
    public new string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
    public static new EnemyAbilityInfo Deserialize(string filename)
    {

        // FIXME: need a better way to handle required fields across inherited members

        EnemyAbilityInfo ability = JsonSerialisationUtils.Deserialize<EnemyAbilityInfo>(filename, REQUIRED_FIELDS.Concat(
            AbilityInfo.REQUIRED_FIELDS).ToList());

        try
        {
            // TODO: range check for telegraph
            // Get all fields of the MyClass type
            FieldInfo[] fields = typeof(EnemyAbilityInfo).GetFields();

            // Display information about each field
            foreach (var field in fields)
            {
                Console.WriteLine($"Field Name: {field.Name}, Type: {field.FieldType}, Accessibility: {field.Attributes}");
            }
        }
        catch
        {
            throw;
        }

        return ability;
    }
}