using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public Conductor conductor;
    public InputManager inputManager;
    [SerializeField] AudioManager audioManager;

    //Audio system based start time (more accurate to music)
    [SerializeField] private float startTime;

    [SerializeField] private float inputTime = -1;
    [SerializeField] private float beatTime = -1;

    //TODO: add bool for checking for cast blocking

    // Start is called before the first frame update
    void Start()
    {
        conductor.onBeatEvent.AddListener(LogBeat);
        inputManager.onInputEvent.AddListener(LogInput);
        audioManager.onPlayEvent.AddListener(Play);
    }

    private void Update()
    {
        if (beatTime > 0 && inputTime < 0)
        {
            float msSinceLastBeat = (float)(AudioSettings.dspTime - startTime - beatTime)*1000;
            if (msSinceLastBeat > 100)
            {
                Debug.Log("Miss by Late");
                ResetTime();
                //TODO: Add Miss Effect
            }
        }

    }

    private void LogInput(float time)
    {
        inputTime = time;
        CheckTiming();
    }

    private void LogBeat(float time)
    {
        beatTime = time;
        CheckTiming();
    }

    private void CheckTiming()
    {
        if (inputTime > 0 && beatTime > 0)
        {
            float timeDifferenceMs = (inputTime - beatTime) * 1000;
            Debug.Log("Time Difference: " + timeDifferenceMs);
            //TODO: apply hit effects
            switch(timeDifferenceMs)
            {
                case > 100:
                    Debug.Log("TOO LATE");
                    break;
                case <= 100 and > 75:
                    Debug.Log("LATE 4");
                    break;
                case <= 75 and > 50:
                    Debug.Log("LATE 3");
                    break;
                case <= 50 and > 25:
                    Debug.Log("LATE 2");
                    break;
                case <= 25 and > 10:
                    Debug.Log("LATE 1");
                    break;
                case <= 10 and >= -10:
                    Debug.Log("PERFECT");
                    break;
                case >= -25 and < -10:
                    Debug.Log("EARLY 1");
                    break;
                case >= -50 and < -25:
                    Debug.Log("EARLY 2");
                    break;
                case >= -75 and < -50:
                    Debug.Log("EARLY 3");
                    break;
                case >= -100 and < -75:
                    Debug.Log("EARLY 4");
                    break;
                case < -100:
                    Debug.Log("TOO EARLY");
                    break;
                default:
                    Debug.Log("INVALID TIME DIFFERENCE");
                    break;
            }

            ResetTime();

        }
    }

    //Reset values every miss or hit
    private void ResetTime()
    {
        inputTime = -1;
        beatTime = -1;
    }

    private void Play()
    {
        //Record the time when the music starts
        startTime = audioManager.startTimeSec;
    }
}
