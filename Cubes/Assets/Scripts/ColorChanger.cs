using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandom(Renderer renderer) => renderer.material.color = Random.ColorHSV();
}
