using UnityEngine;
using System;
using System.Collections;

public class TempTestConductor : MonoBehaviour
{
    [SerializeField] float bpm = 120;

    public float lastBeat { private set; get; }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating(nameof(Tick), 0, 60 / bpm);  // Start after Xs, repeat every Ys
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Tick()
    {
        lastBeat = DateTime.Now.Millisecond;
    }
}
