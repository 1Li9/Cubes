using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SpawnableObject : MonoBehaviour
{
    public IReleasible<SpawnableObject> ReleasePlace { get; set; }
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();
}
