using System.Collections.Generic;
using UnityEngine;

public class PoolPutter : MonoBehaviour
{
    [SerializeField] CubePool _cubePool;

    public void Add(Cube obj) => obj.Interacted += Release;

    private void Release(Cube obj)
    {
        _cubePool.Release(obj);
        obj.Interacted -= Release;
    }
}
