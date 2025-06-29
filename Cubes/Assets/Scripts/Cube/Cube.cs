using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : SpawnebleObject
{
    [SerializeField] private Color _deafultColor = Color.white;
    [SerializeField] private float _minLifeTime = 2.0f;
    [SerializeField] private float _maxLifeTime = 5.0f;

    private Renderer _renderer;
    private bool _wasInteract = false;

    public override Rigidbody Rigidbody { get; protected set; }

    public Renderer Renderer => _renderer;
    public float LifeTime => UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);

    public event Action<Cube> Interacted;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _deafultColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _))
            Interact();
    }

    public override void Setup()
    {
        _renderer.material.color = _deafultColor;
        _wasInteract = false;
    }

    private void Interact()
    {
        if (_wasInteract)
            return;

        _wasInteract = true;
        Interacted?.Invoke(this);
    }
}