using System;
using UnityEngine;

public class CubeInteractedEventPublisher : EventPublisher
{
    [SerializeField] private Cube _cube;

    public override event Action<Vector3> Event;

    public override void Activate() =>
        _cube.Interacted += (cube) => Event?.Invoke(cube.transform.position);

    public override void Deactivate() =>
        _cube.Interacted -= (cube) => Event?.Invoke(cube.transform.position);
}