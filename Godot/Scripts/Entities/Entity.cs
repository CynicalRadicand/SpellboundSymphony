using System.Collections.Generic;
using System.Numerics;
using Godot;
using Vector2 = Godot.Vector2;

public abstract partial class Entity : Node
{
    public static Vector2 DEFAULT_POSITION = new Vector2(1, 1);
    public int hp;
    public string name;
    public Vector2 position;
    public List<StatusEffect> status;
}
