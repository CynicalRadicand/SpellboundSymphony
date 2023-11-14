using Godot;

/// <summary>
/// Handles the display of runes in UI.
/// </summary>
public partial class RuneStoreView : Node
{

    public void UpdateRunes(RuneSequence sequence)
    {
        GD.Print(sequence);
    }

    public void ShowCasting(RuneSequence sequence)
    {
        GD.Print($"Casting runes: {sequence}");
    }

    public void ShowSuccessfulCast(Spell spell)
    {
        GD.Print($"Successfully cast spell: {spell.name}");
    }

    public void ShowFailedCast(string message)
    {
        GD.PrintErr(message);
    }
}
