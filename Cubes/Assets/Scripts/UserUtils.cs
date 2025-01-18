using System;
using System.Collections;
using UnityEngine;

public static class UserUtils
{
    private readonly static System.Random s_random = new();

    public static int GetRandomNumber(int minNumber, int maxNumber) => s_random.Next(minNumber, maxNumber + 1);

    public static float GetRandomNormalizedFloat()
    {
        float normalizeCoefficient = 0.5f;

        return (float)s_random.NextDouble() - normalizeCoefficient;
    }

    public static float GetRandomNormalizedPositiveFloat() => (float)s_random.NextDouble();
}
