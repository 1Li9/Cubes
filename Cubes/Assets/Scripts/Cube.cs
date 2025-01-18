using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour, IInteractable, ISpawnable
{
    [SerializeField] private Color _deafultColor = Color.white;
    [SerializeField] private int _minLifeTime = 2;
    [SerializeField] private int _maxLifeTime = 5;

    private ColorChanger _colorChanger;
    private bool _wasInteract = false;

    public ObjectPool<GameObject> ObjectPool { get; set; }

    public void Interact()
    {
        if (_wasInteract)
            return;

        _colorChanger = GetComponent<ColorChanger>();
        _wasInteract = true;

        if (TryGetComponent(out Renderer renderer))
            _colorChanger.SetRandom(renderer);

        float lifeTime = UserUtils.GetRandomNumber(_minLifeTime, _maxLifeTime);

        Invoke(nameof(Destroy), lifeTime);
    }

    private void Destroy()
    {
        ObjectPool.Release(gameObject);
        _wasInteract = false;

        if (TryGetComponent(out Renderer renderer))
            renderer.material.color = _deafultColor;
    }
}
