using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //Create OnPlayEvent
    public OnPlayEvent onPlayEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource getMusicSource() { return musicSource; }

    public void Play()
    {
        musicSource.loop = true;

        //Record the time when the music starts
        float dspSongStartTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        onPlayEvent.Invoke(dspSongStartTime);
    }
}
