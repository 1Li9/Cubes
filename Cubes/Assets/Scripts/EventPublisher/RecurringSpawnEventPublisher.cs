using System;
using UnityEngine;

public class RecurringSpawnEventPublisher : SpawnEventPublisher
{
    [SerializeField] private Timer _timer;
    [SerializeField] private RandomPositionCalculator _calculator;
    [SerializeField] float _delay;

    private Coroutine _coroutine;

    public override event Action<Vector3> Spawning;

    public override void Activate() =>
        _coroutine = _timer.DoActionRepeating(() => Spawning?.Invoke(_calculator.Calculate()), _delay);

    public override void Deactivate()
    {
        if (_coroutine == null | _timer == null)
            return;

        _timer.StopCoroutine(_coroutine);
        _coroutine = null;
    }
}