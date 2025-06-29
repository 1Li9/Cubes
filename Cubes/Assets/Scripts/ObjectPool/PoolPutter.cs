using UnityEngine;

public abstract class PoolPutter<T> : MonoBehaviour where T : SpawnebleObject
{
    public abstract void Add(T obj);
}
