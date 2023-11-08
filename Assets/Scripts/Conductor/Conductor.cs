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
    [SerializeField] private float secPerBeat = 0;

    //Current song position, in seconds
    [SerializeField] private float songPosSec = 0;

    //Current song position, in beats
    [SerializeField] private float songPosBeats = 0;

    //Audio system based start time (more accurate to music)
    [SerializeField] private float startTime = 0;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private bool playing = false;

    //The previous beat count as an integer to check if the beat changes
    private int prevBeat = 0;

    //Create OnBeatEvent
    public OnBeatEvent onBeatEvent;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.onPlayEvent.AddListener(Play);

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            //determine how many seconds since the song started
            songPosSec = (float)(AudioSettings.dspTime - startTime);

            //determine how many beats since the song started
            songPosBeats = songPosSec / secPerBeat;

            if (TickOver(songPosBeats))
            {
                OnBeat();
            }
        }
    }

    private void Play()
    {
        //Record the time when the music starts
        startTime = audioManager.startTimeSec;

        //Reset variables
        prevBeat = 0;
        //songPosSec = 0;
        //songPosBeats = 0;

        playing = true;
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
        onBeatEvent?.Invoke(songPosSec);
    }

    public float GetPosInBeat()
    {
        return songPosBeats;
    }
}
