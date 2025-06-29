using System;
using UnityEngine;

public class Spawner<T> where T : SpawnebleObject
{
    private readonly ObjectPoolHandler<T> ObjectPool;
    private readonly PoolPutter<T> PoolPutter;
    private readonly Vector3 Position;

    private int _spawnedObjectsCount;

    public event Action<int> SpawnedObjectsCountChanged;

    public Spawner(ObjectPoolHandler<T> cubePool, PoolPutter<T> poolPutter, Vector3 position)
    {
        ObjectPool = cubePool;
        PoolPutter = poolPutter;
        Position = position;
    }

    public void Subscribe(EventPublisher eventPublisher) =>
        eventPublisher.Event += Spawn;

    public void Unsubscribe(EventPublisher eventPublisher) =>
        eventPublisher.Event -= Spawn;

    private void Spawn(Vector3 position)
    {
        T obj = ObjectPool.Get();
        PoolPutter.Add(obj);
        position += Position;  
        obj.transform.position = position;

        _spawnedObjectsCount++;
        SpawnedObjectsCountChanged?.Invoke(_spawnedObjectsCount);
    }
}