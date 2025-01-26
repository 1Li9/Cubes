using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] int _capacity = 5;
    [SerializeField] int _maxSize = 5;

    private ObjectPool<Cube> _objectPool;

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

    public void Release(Cube obj) => _objectPool.Release(obj);

    public Cube Get() => _objectPool.Get();

    private void ActionOnget(Cube obj)
    {
        obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        obj.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Cube obj)
    {
        obj.Rigidbody.velocity = Vector3.zero;
        obj.Rigidbody.angularVelocity = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.gameObject.SetActive(false);
    }
}
