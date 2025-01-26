using System;
using UnityEngine;

[RequireComponent(typeof(ColorChanger), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Interacted;

    [SerializeField] private Color _deafultColor = Color.white;
    [SerializeField] private float _minLifeTime = 2.0f;
    [SerializeField] private float _maxLifeTime = 5.0f;

    private ColorChanger _colorChanger;
    private Renderer _renderer;
    private bool _wasInteract = false;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _colorChanger = GetComponent<ColorChanger>();
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _deafultColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _))
            Interact();
    }

    private void Interact()
    {
        if (_wasInteract)
            return;

        _wasInteract = true;

        _colorChanger.SetRandom(_renderer);

        float lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        StartCoroutine(Timer.DoActionDelayed(() => Destroy(), lifeTime));
    }

    private void Destroy()
    {
        _renderer.material.color = _deafultColor;
        _wasInteract = false;
        Interacted.Invoke(this);
    }
}
