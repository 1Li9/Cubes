using UnityEngine;

[RequireComponent(typeof(ColorChanger), typeof(Renderer), typeof(Rigidbody))]
public class Cube : SpawnableObject, IInteractable
{
    [SerializeField] private Color _deafultColor = Color.white;
    [SerializeField] private int _minLifeTime = 2;
    [SerializeField] private int _maxLifeTime = 5;

    private ColorChanger _colorChanger;
    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private bool _wasInteract = false;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _renderer.material.color = _deafultColor;
    }

    public void Interact()
    {
        if (_wasInteract)
            return;

        _wasInteract = true;

        _colorChanger.SetRandom(_renderer);

        float lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
        Invoke(nameof(Destroy), lifeTime);
    }

    private void Destroy()
    {
        _renderer.material.color = _deafultColor;
        _rigidbody.velocity = Vector3.zero;
        _wasInteract = false;
        ObjectPool.Release(this);
    }
}
