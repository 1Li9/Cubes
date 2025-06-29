using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Bomb : SpawnebleObject
{

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private float _fuseTime;

    private ColorAnimator _colorAnimator;
    private Renderer _renderer;
    private Color _startColor;
    private Color _finalColor;

    public override Rigidbody Rigidbody { get; protected set; }
    public float FuseTime => _fuseTime;

    public event Action<Bomb> Exploded;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _finalColor = _startColor;
        _finalColor.a = 0f;
        _colorAnimator = new ColorAnimator(this);
    }

    public override void Setup()
    {
        _renderer.material.color = _startColor;
        ChangeOpacity();
    }

    public void SetFuseTime(float time) =>
        _fuseTime = time;

    private void ChangeOpacity()
    {
        _colorAnimator.Animate(
            action: (color) => _renderer.material.color = color,
            startColor: _startColor,
            finalValue: _finalColor,
            animationTime: FuseTime,
            callback: Explode);
    }

    private void Explode()
    {
        Collider[] objs = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider obj in objs)
        {
            if (obj.TryGetComponent(out IPhysical physical))
                physical.Rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Exploded?.Invoke(this);
    }
}