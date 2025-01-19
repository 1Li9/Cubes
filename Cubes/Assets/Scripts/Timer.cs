using System;
using System.Collections;
using UnityEngine;

public static class Timer
{
    public static IEnumerator DoActionDelayed(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);

        action?.Invoke();

        yield break;
    }

    public static IEnumerator DoActionRepeating(Action action, float timePeriod)
    {
        WaitForSeconds wait = new(timePeriod);

        while (true)
        {
            action?.Invoke();
            yield return wait;
        }
    }
}
