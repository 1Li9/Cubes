using System;
using UnityEngine;

public abstract class EventPublisher : MonoBehaviour
{
    public abstract event Action<Vector3> Event;

    public abstract void Activate();

    public abstract void Deactivate();
}