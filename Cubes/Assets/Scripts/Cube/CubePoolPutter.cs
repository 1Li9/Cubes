using System;
using UnityEngine;

public class CubePoolPutter : PoolPutter<Cube>
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ObjectPoolHandler<Cube> _cubePool;

    public event Action<Cube> Released;
    
    public override void Add(Cube obj) => 
        obj.Interacted += Release;

    private void Release(Cube cube)
    {
        _timer.DoActionDelayed(
        action: () =>
        {
            _cubePool.Release(cube);
            Released?.Invoke(cube);
        },
        delayTime: cube.LifeTime);

        cube.Interacted -= Release;
    }
}