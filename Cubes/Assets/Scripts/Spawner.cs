using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPoolController _objectPoolController;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _radius;
    [SerializeField] private float _timePeriods;

    private ObjectPool<GameObject> _objectPool;

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
        float xPosition = UserUtils.GetRandomNormalizedFloat() * _radius;
        float yPosition = UserUtils.GetRandomNormalizedFloat() * _radius;
        float zPosition = UserUtils.GetRandomNormalizedFloat() * _radius;
        Vector3 position = new Vector3(xPosition, yPosition, zPosition) + transform.position;

        GameObject obj = _objectPool.Get();

        if (obj.TryGetComponent(out ISpawnable spawnable))
            spawnable.ObjectPool = _objectPool;

        obj.transform.position = position;
    }
}
