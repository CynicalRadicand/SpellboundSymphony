using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Event for OnInput, includes Position in song by seconds
[System.Serializable]
public class OnInputEvent : UnityEvent<float>
{
}
