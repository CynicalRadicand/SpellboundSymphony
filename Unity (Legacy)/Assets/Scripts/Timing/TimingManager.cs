using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class TimingManager : MonoBehaviour
{
    public Conductor conductor;
    public InputManager inputManager;
    [SerializeField] AudioManager audioManager;

    //Audio system based start time (more accurate to music)
    [SerializeField] private float startTime = 0;

    [SerializeField] private float inputTime = -1;
    [SerializeField] private float beatTime = -1;

    private int combo = 0;

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
        if (beatTime > 0 && inputTime < 0 && combo > 0)
        {
            float msSinceLastBeat = (float)(AudioSettings.dspTime - startTime - beatTime)*1000;
            if (msSinceLastBeat > 100)
            {
                Debug.Log("Miss by Late");
                Miss();
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

            //TODO: Time difference to animate slider for accuracy visualisation
            switch(timeDifferenceMs)
            {
                case <= 10 and >= -10:
                    Debug.Log("PERFECT");
                    Hit(Timings.PERFECT);
                    break;
                case <= 25 and >+ -25:
                    Debug.Log("EXCELLENT");
                    Hit(Timings.EXCELLENT);
                    break;
                case <= 50 and >= -50:
                    Debug.Log("GREAT");
                    Hit(Timings.GREAT);
                    break;
                case <= 75 and >= -75:
                    Debug.Log("GOOD");
                    Hit(Timings.GOOD);
                    break;
                case <= 100 and >= -100:
                    Debug.Log("POOR");
                    Hit(Timings.POOR);
                    break;
                default:
                    Debug.Log("MISS");
                    Miss();
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

        ResetTime();
    }

    private void Hit(Timings timings) {
        //TODO: Play animation and add rune with timing and combo multipliers
        combo++;
        ResetTime();
    }
    //Or
    private void Miss()
    {
        //TODO: Clear runes and play miss animation
        combo = 0;
        ResetTime();
    }
    //I guess they never miss huh?
}
