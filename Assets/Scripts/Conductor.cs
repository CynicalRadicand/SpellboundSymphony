using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Pulse Border
    public GameObject Border;

    private int PrevBeat = 0;

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

        if (CurBeat>PrevBeat) {
            PrevBeat = Mathf.FloorToInt(beat);
            return true;
        }

        PrevBeat = Mathf.FloorToInt(beat);
        return false;
    }

    //Triggers on Beat
    private void OnBeat()
    {
        Debug.Log("ONBEAT"+PrevBeat);
        //Border.GetComponent<Fade>().Pulse();
    }

    public float GetPosInBeat()
    {
        return songPositionInBeats;
    }
}
