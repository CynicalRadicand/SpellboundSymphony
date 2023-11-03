using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Conductor : MonoBehaviour
{
    //Song BPM
    public float songBpm;

    //The number of seconds for each song beat
    [SerializeField] private float secPerBeat;

    //Current song position, in seconds
    [SerializeField] private float songPositionInSec;

    //Current song position, in beats
    [SerializeField] private float songPositionInBeats;

    //Audio system based start time (more accurate to music)
    [SerializeField] private float dspSongStartTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The previous beat count as an integer to chec kif the beat changes
    private int prevBeat = 0;

    //Create OnBeatEvent
    public OnBeatEvent onBeatEvent;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        musicSource.loop = true;

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongStartTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPositionInSec = (float)(AudioSettings.dspTime - dspSongStartTime);

        //determine how many beats since the song started
        songPositionInBeats = songPositionInSec / secPerBeat;

        if (TickOver(songPositionInBeats))
        {
            OnBeat();
        }
    }

    //Detects when the beat ticks over
    private bool TickOver(float beat)
    {
        int CurBeat = Mathf.FloorToInt(beat);

        if (CurBeat>prevBeat) {
            prevBeat = Mathf.FloorToInt(beat);
            return true;
        }

        return false;
    }

    //Triggers on Beat
    private void OnBeat()
    {
        //Evoke the OnBeatEvent to subscribers
        onBeatEvent?.Invoke(songPositionInSec);
    }

    public float GetPosInBeat()
    {
        return songPositionInBeats;
    }
}
