using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup border;

    private void Update()
    {
        border.alpha -= Time.deltaTime;
    }

    public void Pulse()
    {
        border.alpha = 1;
    }
}
