using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolController : MonoBehaviour, IReleasible<SpawnableObject>
{
    [SerializeField] private SpawnableObject _prefab;
    [SerializeField] int _capacity = 5;
    [SerializeField] int _maxSize = 5;

    private ObjectPool<SpawnableObject> _objectPool;

    private void Awake()
    {
        _objectPool = new(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnget(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize
            );
    }

    public SpawnableObject Get() => _objectPool.Get();
    public void Release(SpawnableObject obj) => _objectPool.Release(obj);

    private void ActionOnget(SpawnableObject obj)
    {
        obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        obj.gameObject.SetActive(true);
    }

    private static void ActionOnRelease(SpawnableObject obj)
    {
        obj.Rigidbody.velocity = Vector3.zero;
        obj.Rigidbody.angularVelocity = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.gameObject.SetActive(false);
    }
}
