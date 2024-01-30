using System.Collections.Generic;
using Godot;

public partial class Entity : Node
{
    [Export] public string name;
    [Export] public int hp;
    public List<StatusEffect> status;

    [Export] protected Conductor conductor;

    public override void _Ready()
    {
        
    }
}
