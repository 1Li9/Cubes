using System;
using UnityEngine;

public class CubeReleasedEventPublisher : EventPublisher
{
    [SerializeField] private CubePoolPutter _cubePoolPutter;

    public override event Action<Vector3> Event;

    public override void Activate() =>
        _cubePoolPutter.Released += (cube) => Event?.Invoke(cube.transform.position);

    public override void Deactivate() =>
        _cubePoolPutter.Released -= (cube) => Event?.Invoke(cube.transform.position);
}