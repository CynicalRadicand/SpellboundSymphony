using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Event for OnBeat, includes Position in song by seconds
[System.Serializable]
public class OnBeatEvent : UnityEvent<float>
{
}
