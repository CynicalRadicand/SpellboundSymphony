using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public Conductor conductor;
    public InputManager inputManager;

    [SerializeField] private float inputTime = -1;
    [SerializeField] private float beatTime = -1;

    //TODO: add bool for checking for cast blocking

    // Start is called before the first frame update
    void Start()
    {
        conductor.onBeatEvent.AddListener(LogBeat);
        inputManager.onInputEvent.AddListener(LogInput);
    }

    private void LogInput(float time)
    {
        if (inputTime > 0) {
            //TODO: Apply miss effects
            Debug.Log("Miss by double input");
            ResetTime();
        }
        inputTime = time;
        CheckTiming();
    }

    private void LogBeat(float time)
    {
        if (beatTime > 0)
        {
            //TODO: Apply miss effects
            Debug.Log("Miss by double beat");
            ResetTime();
        }
        beatTime = time;
        CheckTiming();
    }

    private void CheckTiming()
    {
        if (inputTime > 0 && beatTime > 0)
        {
            float timeDifferenceMs = (inputTime - beatTime) * 1000;
            Debug.Log("Time Difference: " + timeDifferenceMs);
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
                    Debug.Log("SUMTING WONG");
                    break;
            }

            ResetTime();

        }
    }

    private void ResetTime()
    {
        inputTime = 0;
        beatTime = 0;
    }
}
