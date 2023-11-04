using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //Create OnPlayEvent
    public OnPlayEvent onPlayEvent;

    public float startTimeSec;

    public AudioSource getMusicSource() { return musicSource; }

    private void Start()
    {
        musicSource.loop = true;

        musicSource.playOnAwake = false;
    }

    public void Play()
    {
        //Record the time when the music starts
        startTimeSec = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        onPlayEvent.Invoke();
    }
}
