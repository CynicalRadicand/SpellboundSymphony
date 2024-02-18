using System.Collections.Generic;
using Godot;

public partial class SpellBook : Node
{
    // TODO: consider abstracting loadouts even further beyond lists
    private List<PlayerAbilityInfo> loadout;

    public SpellBook()
    {
        loadout = new List<PlayerAbilityInfo>();
    }

    public void AddSpell(PlayerAbilityInfo spell)
    {
        loadout.Add(spell);
    }

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
        throw new SpellNotFoundException($"Spell with runes {runeSequence} does not exist in loadout.");
    }
}