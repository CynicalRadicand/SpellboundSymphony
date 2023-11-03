using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] KeyBindings keyBindings;
    [SerializeField] RuneStorePresenter storePresenter;
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyBindings.KeyAir))
        {
            storePresenter.AddRune(new Rune(Elements.AIR, "A"));
        }
        if (Input.GetKeyDown(keyBindings.KeyFire))
        {
            storePresenter.AddRune(new Rune(Elements.FIRE, "F"));
        }
        if (Input.GetKeyDown(keyBindings.KeyEarth))
        {
            storePresenter.AddRune(new Rune(Elements.EARTH, "E"));
        }
        if (Input.GetKeyDown(keyBindings.KeyWater))
        {
            storePresenter.AddRune(new Rune(Elements.WATER, "W"));
        }
        if (Input.GetKeyDown(keyBindings.KeyConfirm))
        {
            audioManager.Play();
        }
    }
}
