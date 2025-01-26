using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private PoolPutter _poolPutter;
    [SerializeField] private float _radius;
    [SerializeField] private float _timePeriod;

    private void Start()
    {
        StartCoroutine(Timer.DoActionRepeating(() => Spawn(), _timePeriod));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radius);
    }

    private void Spawn()
    {
        Cube obj = _cubePool.Get();
        Vector3 position = Random.insideUnitSphere * _radius + transform.position;
        _poolPutter.Add(obj);
        obj.transform.position = position;
    }
}
