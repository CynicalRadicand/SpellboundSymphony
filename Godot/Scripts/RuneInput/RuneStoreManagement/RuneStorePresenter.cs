using Godot;
using System.Collections.Generic;

public partial class RuneStorePresenter : Node
{
    [Export] private NodePath spellCastPresenterPath;

    RuneStoreView storeView;
    RuneStoreController storeController;
    SpellCastPresenter spellCastPresenter;

    public override void _Ready()
    {
        storeView = GetNode<RuneStoreView>("RuneStoreView");
        storeController = GetNode<RuneStoreController>("RuneStoreController");
        spellCastPresenter = GetNode<SpellCastPresenter>(spellCastPresenterPath);
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
}
