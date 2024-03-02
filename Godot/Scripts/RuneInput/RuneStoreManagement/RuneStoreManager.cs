using Godot;
using System.Collections.Generic;

public partial class RuneStoreManager : Node
{
    /// <summary>
    /// Reason for referencing player directly: Better to have external managers 
    /// reference the player, rather than the player referencing all the managers.
    /// </summary>
    [Export] private Player player;
    [Export] private NodePath timingManagerPath;

    private TimingManager timingManager;

    RuneStoreView storeView;
    RuneStore runeStore;



    public override void _Ready()
    {
        storeView = GetNode<RuneStoreView>("RuneStoreView");
        runeStore = GetNode<RuneStore>("RuneStoreController");

        timingManager = GetNode<TimingManager>(timingManagerPath);
        timingManager.TimingInput += HandleInput;

        player.FinishInput += HandleMeasureClear;
    }

    public void AddRune(Rune rune)
    {
        runeStore.EnqueueRune(rune);

        // Update the current runes in UI
        storeView.UpdateRunes(new RuneSequence(runeStore.GetRunes()));

        if (runeStore.IsFull())
        {
            TryCastRunes();
        }
    }

    private void TryCastRunes()
    {
        RuneSequence runes = new(runeStore.GetRunes());
        storeView.ShowCasting(runes);

        try
        {
            // Check if ability exists in loadout
            PlayerAbilityInfo ability = player.spellBook.GetSpellByRunes(runes);

            // TODO: check for misses
            // if -> HandleMiss();

            //TODO: send signal to player
            player.SetAbility(ability);
            storeView.ShowSuccessfulCast(ability); // TODO: replace with UI updates
        }
        catch (SpellNotFoundException)
        {
            storeView.ShowFailedCast("Incorrect rune order.");
            // Fizzles (in Player), do not set any ability 
        }

        runeStore.ClearQueue();
    }

    private void HandleMeasureClear()
    {
        runeStore.ClearQueue();
    }

    // TODO: see how to integrate this with Conductor class
    private void HandleMiss()
    {
        // Combo break etc.

        storeView.ShowFailedCast("Spell casting was broken!");

        runeStore.ClearQueue();
    }

    //TODO: add to signal listener
    private void HandleInput(InputDTO inputDTO)
    {
        if (inputDTO.KeyAction == Elements.AIR)
        {
            AddRune(new Rune(Elements.AIR, "A", inputDTO.Accuracy));
        }
        if (inputDTO.KeyAction == Elements.FIRE)
        {
            AddRune(new Rune(Elements.FIRE, "F", inputDTO.Accuracy));
        }
        if (inputDTO.KeyAction == Elements.EARTH)
        {
            AddRune(new Rune(Elements.EARTH, "E", inputDTO.Accuracy));
        }
        if (inputDTO.KeyAction == Elements.WATER)
        {
            AddRune(new Rune(Elements.WATER, "W", inputDTO.Accuracy));
        }
    }
}
