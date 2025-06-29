using System;
using System.Collections;
using UnityEngine;

public class ColorAnimator
{
    private readonly int StepsCount = 120;
    private readonly float TimeStep = 1.0f;
    private readonly MonoBehaviour Context;

    private Coroutine _coroutine;

    public ColorAnimator(MonoBehaviour context) =>
        Context = context;

    public void Animate(Action<Color> action, Color startColor, Color finalValue, float animationTime, Action callback)
    {
        if (_coroutine != null)
        {
            Context.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = Context.StartCoroutine(AnimateCoroutine(action, startColor, finalValue, animationTime, callback));
    }

    private IEnumerator AnimateCoroutine(Action<Color> action, Color startValue, Color finalValue, float animationTime, Action callback)
    {
        animationTime = Mathf.Clamp(animationTime, 0f, StepsCount);
        float animationStep = TimeStep / StepsCount;
        float progress = 0f;

        WaitForSecondsRealtime wait = new(animationTime / StepsCount);

        while (progress < 1f)
        {
            startValue = Color.LerpUnclamped(startValue, finalValue, animationStep);
            progress += animationStep;
            action?.Invoke(startValue);

            yield return wait;
        }

        action?.Invoke(finalValue);
        callback?.Invoke();
    }
}