using UnityEngine;

public class SpawnerHandler<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private ObjectPoolHandler<T> _objectPool;
    [SerializeField] private PoolPutter<T> _poolPutter;
    [SerializeField] private SpawnEventPublisher _eventPublisher;

    private Spawner<T> _spawner;

    private void OnEnable()
    {
        _spawner = new Spawner<T>(_objectPool, _poolPutter, transform.position);
        _spawner.Subscribe(_eventPublisher);
    }

    private void OnDisable()
    {
        _spawner.Unsubscribe(_eventPublisher);
        _eventPublisher.Deactivate();
    }

    private void Start() =>
        _eventPublisher.Activate();
}