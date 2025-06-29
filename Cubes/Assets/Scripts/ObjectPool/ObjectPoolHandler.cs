using System;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolHandler<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private T _prefab;
    [SerializeField] int _capacity = 5;
    [SerializeField] int _maxSize = 5;

    private ObjectPool<T> _objectPool;

    private int _objectsCount;
    private int _activeObjectsCount;

    public event Action<int> ObjectsCountChanged;
    public event Action<int> ActiveObjectsCountChanged;

    private void Awake()
    {
        _objectPool = new(
            createFunc: CreateFunc,
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize
            );
    }

    public void Release(T obj)
    {
        _objectPool.Release(obj);

        _activeObjectsCount--;
        if(_activeObjectsCount < 0 )
            _activeObjectsCount = 0;

        ActiveObjectsCountChanged?.Invoke(_activeObjectsCount);
    }

    public T Get()
    {
        _activeObjectsCount++;
        ActiveObjectsCountChanged?.Invoke(_activeObjectsCount);

        return _objectPool.Get();
    }

    private T CreateFunc()
    {
        _objectsCount++;
        ObjectsCountChanged?.Invoke(_objectsCount);

        return Instantiate(_prefab);
    }

    private void ActionOnGet(T obj)
    {
        obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        obj.gameObject.SetActive(true);
        obj.Setup();
    }

    private void ActionOnRelease(T obj)
    {
        obj.Rigidbody.velocity = Vector3.zero;
        obj.Rigidbody.angularVelocity = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.gameObject.SetActive(false);
    }
}