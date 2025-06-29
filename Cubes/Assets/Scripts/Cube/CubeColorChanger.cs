using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable() =>
        _cube.Interacted += (cube)=> SetRandom(cube.Renderer);

    private void OnDisable() =>
        _cube.Interacted -= (cube)=> SetRandom(cube.Renderer);

    private void SetRandom(Renderer renderer) =>
        renderer.material.color = Random.ColorHSV();
}
