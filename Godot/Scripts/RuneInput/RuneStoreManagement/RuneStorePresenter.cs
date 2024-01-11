using Godot;
using System.Collections.Generic;

public partial class RuneStorePresenter : Node
{
    [Export] private NodePath spellCastPresenterPath;
    [Export] private NodePath timingManagerPath;

    private TimingManager timingManager;

    RuneStoreView storeView;
    RuneStoreController storeController;
    SpellCastPresenter spellCastPresenter;

    public override void _Ready()
    {
        storeView = GetNode<RuneStoreView>("RuneStoreView");
        storeController = GetNode<RuneStoreController>("RuneStoreController");
        spellCastPresenter = GetNode<SpellCastPresenter>(spellCastPresenterPath);

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
        List<Rune> runes = storeController.GetRunes();
        storeView.ShowCasting(new RuneSequence(runes));

        Spell spell = spellCastPresenter.GetSpell(runes);

        if (spell != null)
        {
            storeView.ShowSuccessfulCast(spell);
        }
        else
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
