using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup border;
    [SerializeField] private GameObject conductor;

    private void Update()
    {
        float beat = conductor.GetComponent<Conductor>().GetPosInBeat();

        // fade proportional to last beat
        border.alpha = 1 - (beat % 1);
    }
}
