using UnityEngine;

public abstract class Description<T> : MonoBehaviour where T : ScriptableObject
{
    public T Data { get; protected set; }

    public abstract void Construct(T data);
}
