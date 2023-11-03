using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Event for OnPlay, includes start time in song by seconds
[System.Serializable]
public class OnPlayEvent : UnityEvent<float>
{
}