using System.Collections.Generic;
using Godot;

public partial class SpellBook : Node
{
    // TODO: consider abstracting loadouts even further beyond lists
    private List<PlayerAbilityInfo> loadout;

    public void SetLoadout(List<PlayerAbilityInfo> newLoadout)
    {
        loadout = newLoadout;
    }

    public void ClearLoadout()
    {
        loadout.Clear();
    }

    public PlayerAbilityInfo GetSpellByRunes(RuneSequence runeSequence)
    {
        foreach (PlayerAbilityInfo ability in loadout)
        {
            if (ability.runeSequence.Equals(runeSequence))
            {
                return ability;
            }
        }
        throw new SpellNotFoundException(string.Format("Spell with runes {0} does not exist in loadout.", runeSequence));
    }
}