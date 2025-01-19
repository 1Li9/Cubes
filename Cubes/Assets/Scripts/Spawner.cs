using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPoolController _objectPoolController;
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
        SpawnableObject obj = _objectPoolController.Get();
        Vector3 position = Random.insideUnitSphere * _radius + transform.position;

        obj.ReleasePlace = _objectPoolController;
        obj.transform.position = position;
    }
}
