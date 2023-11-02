using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles the display of runes in UI.
/// </summary>
public class RuneStoreView : MonoBehaviour
{

    public void UpdateRunes(RuneSequence sequence)
    {
        Debug.Log(sequence);
    }

    public void ShowCasting(RuneSequence sequence)
    {
        Debug.Log($"Casting runes: {sequence}");
    }

    public void ShowSuccessfulCast(Spell spell)
    {
        Debug.Log($"Successfully cast spell: {spell}");
    }

    public void ShowFailedCast(string message)
    {
        Debug.LogError(message);
    }
}
