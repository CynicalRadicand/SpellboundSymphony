using System.Collections.Generic;
using Godot;
using Vector2 = Godot.Vector2;

public partial class Entity : Node
{
    public string name;
    public int hp;
    public Vector2 position;
    public List<StatusEffect> status;
}
