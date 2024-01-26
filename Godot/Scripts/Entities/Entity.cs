using System.Collections.Generic;
using System.Numerics;
using Godot;
using Vector2 = Godot.Vector2;

public abstract partial class Entity : Node
{
    public int hp;
    public string name;
    public Vector2 position;
    public List<StatusEffect> status;
}
