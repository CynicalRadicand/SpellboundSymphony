using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Ability
{
    public string name { get; set; }
    // public AbilityType type { get; set; }
    // public string description { get; set; }
    public int chance { get; set; } = 1;
    public int damage { get; set; } = 0;
    public int heal { get; set; } = 0;
    public int shield { get; set; } = 0;
    public List<StatusEffect> statusIncoming { get; set; } = new List<StatusEffect>();
    public List<StatusEffect> statusOutgoing { get; set; } = new List<StatusEffect>();
    public List<Position> target { get; set; } = new List<Position>();
    public int telegraph { get; set; } = 1;
}
