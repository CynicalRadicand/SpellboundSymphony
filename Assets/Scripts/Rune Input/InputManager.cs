using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] KeyBindings keyBindings;
    [SerializeField] RuneStorePresenter storePresenter;
    [SerializeField] AudioManager audioManager;

    //Audio system based start time (more accurate to music)
    [SerializeField] private float startTime = 0;

    //Create OnBeatEvent
    public OnInputEvent onInputEvent;

    //Current song position, in seconds
    [SerializeField] private float songPosSec;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.onPlayEvent.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate current song dsp time
        songPosSec = (float)(AudioSettings.dspTime - startTime);

        if (Input.GetKeyDown(keyBindings.KeyAir))
        {
            //storePresenter.AddRune(new Rune(Elements.AIR, "A"));
            onInputEvent?.Invoke(songPosSec);
        }
        if (Input.GetKeyDown(keyBindings.KeyFire))
        {
            //storePresenter.AddRune(new Rune(Elements.FIRE, "F"));
            onInputEvent?.Invoke(songPosSec);
        }
        if (Input.GetKeyDown(keyBindings.KeyEarth))
        {
            //storePresenter.AddRune(new Rune(Elements.EARTH, "E"));
            onInputEvent?.Invoke(songPosSec);
        }
        if (Input.GetKeyDown(keyBindings.KeyWater))
        {
            //storePresenter.AddRune(new Rune(Elements.WATER, "W"));
            onInputEvent?.Invoke(songPosSec);
        }
        if (Input.GetKeyDown(keyBindings.KeyConfirm))
        {
            audioManager.Play();
        }
    }

    private void Play()
    {
        //Record the time when the music starts
        startTime = audioManager.startTimeSec;
    }
}
