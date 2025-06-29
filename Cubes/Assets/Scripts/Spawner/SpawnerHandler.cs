using System;
using UnityEngine;

public class SpawnerHandler<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ObjectPoolHandler<T> _objectPool;
    [SerializeField] private PoolPutter<T> _poolPutter;
    [SerializeField] private EventPublisher _eventPublisher;
    [SerializeField] private float _timePeriod;

    private Spawner<T> _spawner;

    public event Action<int> SpawnedObjectsCountChanged;
    public event Action<int> ObjectsCountChanged;
    public event Action<int> ActiveObjectsCountChanged;

    private void OnEnable()
    {
        _spawner = new Spawner<T>(_objectPool, _poolPutter, transform.position);
        _spawner.Subscribe(_eventPublisher);

        _spawner.SpawnedObjectsCountChanged += (value) => SpawnedObjectsCountChanged?.Invoke(value);
        _objectPool.ObjectsCountChanged += (value) => ObjectsCountChanged?.Invoke(value);
        _objectPool.ActiveObjectsCountChanged += (value) => ActiveObjectsCountChanged?.Invoke(value);
    }

    private void OnDisable()
    {
        _spawner.Unsubscribe(_eventPublisher);
        _eventPublisher.Deactivate();

        _spawner.SpawnedObjectsCountChanged -= (value) => SpawnedObjectsCountChanged?.Invoke(value);
        _objectPool.ObjectsCountChanged -= (value) => ObjectsCountChanged?.Invoke(value);
        _objectPool.ActiveObjectsCountChanged -= (value) => ActiveObjectsCountChanged?.Invoke(value);
    }

    private void Start() =>
        _eventPublisher.Activate();
}