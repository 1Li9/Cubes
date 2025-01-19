using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPoolController _objectPoolController;
    [SerializeField] private float _radius;
    [SerializeField] private float _timePeriods;

    private ObjectPool<SpawnableObject> _objectPool;

    private void Start()
    {
        _objectPool = _objectPoolController.ObjectPool;
        InvokeRepeating(nameof(Spawn), 0.0f, _timePeriods);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radius);
    }

    private void Spawn()
    {
        SpawnableObject obj = _objectPool.Get();
        Vector3 position = Random.insideUnitSphere * _radius + transform.position;

        obj.ObjectPool = _objectPool;
        obj.transform.position = position;
    }
}
