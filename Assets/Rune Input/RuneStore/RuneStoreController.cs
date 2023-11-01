using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Represents the rune store and is solely responsible for storage (no logic).
/// </summary>
public class RuneStoreController : MonoBehaviour
{
    [SerializeField] List<Rune> runes;

    private void Start()
    {
        runes = new List<Rune>();
    }




    public List<Rune> GetRunes()
    {
        return runes;
    }

    public void EnqueueRune(Rune rune)
    {
        runes.Add(rune);
    }

    public void ClearQueue()
    {
        runes.Clear();
    }

    public int GetSize()
    {
        return runes.Count;
    }
}
