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

    public void ShowSuccessfulCast(PlayerAbilityInfo ability)
    {
        GD.Print($"Successfully cast spell: {ability.name}");
    }

    public void ShowFailedCast(string message)
    {
        GD.PrintErr(message);
    }
}
