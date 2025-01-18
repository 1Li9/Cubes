using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandom(Renderer renderer)
    {
        float red = UserUtils.GetRandomNormalizedPositiveFloat();
        float green = UserUtils.GetRandomNormalizedPositiveFloat();
        float blue = UserUtils.GetRandomNormalizedPositiveFloat();
        Color color = new(red, green, blue);

        renderer.material.color = color;
    }
}
