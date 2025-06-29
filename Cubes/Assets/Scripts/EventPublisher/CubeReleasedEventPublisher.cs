using System;
using UnityEngine;

public class CubeReleasedEventPublisher : SpawnEventPublisher
{
    [SerializeField] private CubePoolPutter _cubePoolPutter;

    public override event Action<Vector3> Spawning;

    public override void Activate() =>
        _cubePoolPutter.Released += (cube) => Spawning?.Invoke(cube.transform.position);

    public override void Deactivate() =>
        _cubePoolPutter.Released -= (cube) => Spawning?.Invoke(cube.transform.position);
}