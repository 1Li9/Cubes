using UnityEngine.Pool;
using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    public ObjectPool<SpawnableObject> ObjectPool { get; set; }
}
