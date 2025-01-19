using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] private SpawnableObject _prefab;
    [SerializeField] int _capacity = 5;
    [SerializeField] int _maxSize = 5;

    public ObjectPool<SpawnableObject> ObjectPool { get; private set; }

    private void Awake()
    {
        ObjectPool = new(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnget(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize
            );
    }

    private void ActionOnget(SpawnableObject obj)
    {
        obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        obj.gameObject.SetActive(true);
    }
}
