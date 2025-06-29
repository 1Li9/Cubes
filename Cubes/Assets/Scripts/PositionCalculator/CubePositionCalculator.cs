using UnityEngine;

public class RandomPositionCalculator : MonoBehaviour
{
    [SerializeField] private float _radius;

    public Vector3 Calculate() =>
        Random.insideUnitSphere * _radius;
}