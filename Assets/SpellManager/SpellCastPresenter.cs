using UnityEngine;
using System.Collections.Generic;

public class SpellCastPresenter : MonoBehaviour
{
    /// <summary>
    /// Get spell that corresponds to this order of runes.
    /// 
    /// Returns null if order of runes does not corresponds to any spell.
    /// </summary>
    /// <param name="runes"></param>
    /// <returns></returns>
    public Spell GetSpell(List<Rune> runes)
    {
        // TODO: check if order of runes corresponds to any spell.
        return new Spell("Dummy Spell");

        // return null;
    }
}
