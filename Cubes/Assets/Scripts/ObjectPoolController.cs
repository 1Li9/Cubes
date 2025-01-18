using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] int _capacity = 5;
    [SerializeField] int _maxSize = 5;

    public ObjectPool<GameObject> ObjectPool { get; private set; }

    private void Start()
    {
        ObjectPool = new(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnget(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize
            );
    }

    private void ActionOnget(GameObject obj)
    {
        obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        obj.SetActive(true);
    }
}
