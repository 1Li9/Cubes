using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SpawnebleObject : MonoBehaviour, IPhysical
{
    public abstract Rigidbody Rigidbody { get; protected set; }

    public abstract void Setup();
}
