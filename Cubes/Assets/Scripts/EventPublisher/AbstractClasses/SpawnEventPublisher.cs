using System;
using UnityEngine;

public abstract class SpawnEventPublisher : MonoBehaviour
{
    public abstract event Action<Vector3> Spawning;

    public abstract void Activate();

    public abstract void Deactivate();
}