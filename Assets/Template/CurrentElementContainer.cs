using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentElementContainer<T> : MonoBehaviour where T : ScriptableObject
{
    public T CurrentElement { get; set; }
}
