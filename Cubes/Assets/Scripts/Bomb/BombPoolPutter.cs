using UnityEngine;

public class BombPoolPutter : PoolPutter<Bomb>
{
    [SerializeField] private ObjectPoolHandler<Bomb> _bombPool;
    [SerializeField] private float _minFuseTime;
    [SerializeField] private float _maxFuseTime;

    public override void Add(Bomb bomb)
    {
        bomb.Exploded += Release;

        float fuseTime = Random.Range(_maxFuseTime, _minFuseTime);
        bomb.SetFuseTime(fuseTime);
    }

    private void Release(Bomb bomb)
    {
        _bombPool.Release(bomb);
        bomb.Exploded -= Release;
    }
}