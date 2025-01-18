using UnityEngine.Pool;
using UnityEngine;

public interface ISpawnable
{
    public ObjectPool<GameObject> ObjectPool { get; set; }
}
