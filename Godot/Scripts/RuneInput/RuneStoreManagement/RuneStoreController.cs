using Godot;
using System.Collections.Generic;

/// <summary>
/// Represents the rune store and is solely responsible for storage (no logic).
/// </summary>
public partial class RuneStoreController : Node
{
    private List<Rune> runes;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        runes = new();
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

    public bool IsFull()
    {
        return runes.Count == 4;
    }

    public override string ToString()
    {
        return new RuneSequence(runes).ToString();
    }
}
