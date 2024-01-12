using System.Collections.Generic;

public class Ability
{
    public string name { get; set; }
    public AbilityType type { get; set; }
    public int chance { get; set; }
    public int damage { get; set; }
    public int heal { get; set; }
    public int shield { get; set; }
    public List<StatusEffect> statusIncoming { get; set; }
    public List<StatusEffect> statusOutgoing { get; set; }
    public Target target { get; set; }
    public int telegraph {  get; set; }
}
