using Godot;
using System;
using System.Collections.Generic;

public partial class Ability : GodotObject
{
    public string name { get; set; }
    public AbilityType type { get; set; }
    public int chance { get; set; }
    public int damage { get; set; }
    public int heal { get; set; }
    public int shield { get; set; }
    public List<Status> buff { get; set; }
    public List<Status> debuff { get; set; }
    public Target target { get; set; }
    public int telegraph {  get; set; }
}
