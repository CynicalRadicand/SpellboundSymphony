using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Conductor conductor;

    // Start is called before the first frame update
    void Start()
    {
        conductor.onBeatEvent.AddListener(onbeat);
    }

    private void onbeat(float sec)
    {
        Debug.Log(sec);
    }
}
