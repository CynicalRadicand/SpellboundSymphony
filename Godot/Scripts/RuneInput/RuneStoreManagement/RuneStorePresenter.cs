using Godot;
using System.Collections.Generic;

public partial class RuneStorePresenter : Node
{
    /// <summary>
    /// Reason for referencing player directly: Better to have external managers 
    /// reference the player, rather than the player referencing all the managers.
    /// </summary>
    [Export] private Player player;
    [Export] private NodePath timingManagerPath;

    private TimingManager timingManager;

    RuneStoreView storeView;
    RuneStoreController storeController;



    public override void _Ready()
    {
        storeView = GetNode<RuneStoreView>("RuneStoreView");
        storeController = GetNode<RuneStoreController>("RuneStoreController");

        timingManager = GetNode<TimingManager>(timingManagerPath);
        timingManager.TimingInput += HandleInput;
    }

    public void AddRune(Rune rune)
    {

        // TODO: replace with check from Conductor class
        bool isOnBeat = true;

        if (!isOnBeat)
        {
            HandleMiss();
        }

        storeController.EnqueueRune(rune);

        // Update the current runes in UI
        storeView.UpdateRunes(new RuneSequence(storeController.GetRunes()));

        if (storeController.IsFull())
        {
            CastRunes();
        }
    }

    private void CastRunes()
    {
        RuneSequence runes = new(storeController.GetRunes());
        storeView.ShowCasting(runes);

        try
        {
            PlayerAbilityInfo ability = player.spellBook.GetSpellByRunes(runes);
            storeView.ShowSuccessfulCast(ability);

            //TODO: send signal to player
            player.SetAbility(ability);
        }
        catch (SpellNotFoundException)
        {
            storeView.ShowFailedCast("Incorrect rune order.");
        }

        storeController.ClearQueue();
    }

    // TODO: see how to integrate this with Conductor class
    private void HandleMiss()
    {
        // Combo break etc.

        storeView.ShowFailedCast("Spell casting was broken!");

        storeController.ClearQueue();
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
