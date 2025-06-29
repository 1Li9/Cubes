using System;
using UnityEngine;

public class Spawner<T> where T : SpawnebleObject
{
    private readonly ObjectPoolHandler<T> _objectPool;
    private readonly PoolPutter<T> _poolPutter;
    private readonly Vector3 _position;

    public Spawner(ObjectPoolHandler<T> cubePool, PoolPutter<T> poolPutter, Vector3 position)
    {
        _objectPool = cubePool;
        _poolPutter = poolPutter;
        _position = position;
    }

    public void Subscribe(SpawnEventPublisher eventPublisher) =>
        eventPublisher.Spawning += Spawn;

    public void Unsubscribe(SpawnEventPublisher eventPublisher) =>
        eventPublisher.Spawning -= Spawn;

    public void Spawn(Vector3 position)
    {
        T obj = _objectPool.Get();
        _poolPutter.Add(obj);
        position += _position;  
        obj.transform.position = position;
    }
}