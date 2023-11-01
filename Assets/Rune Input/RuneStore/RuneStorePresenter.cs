using UnityEngine;
using System.Collections;

public class RuneStorePresenter : MonoBehaviour
{
    RuneStoreController storeController;

    public void AddRune(Rune rune)
    {
        if (storeController.GetSize() < 4)
        {
            storeController.EnqueueRune(rune);
        } else
        {
            // TODO: how to handle over-inputs
        }
    }

}
