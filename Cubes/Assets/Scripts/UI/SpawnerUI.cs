using UnityEngine;
using TMPro;

public class SpawnerUI<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private SpawnerHandler<T> _spawner;

    [SerializeField] private TMP_Text _spawnedObjectsCount;
    [SerializeField] private TMP_Text _objectsCount;
    [SerializeField] private TMP_Text _activeObjectsCount;

    private void OnEnable()
    {
        _spawner.SpawnedObjectsCountChanged += SetSpawnedObjectsCount;
        _spawner.ObjectsCountChanged += SetObjectsCount;
        _spawner.ActiveObjectsCountChanged += SetActiveObjectsCount;
    }

    private void OnDisable()
    {
        _spawner.SpawnedObjectsCountChanged -= SetSpawnedObjectsCount;
        _spawner.ObjectsCountChanged -= SetObjectsCount;
        _spawner.ActiveObjectsCountChanged -= SetActiveObjectsCount;
    }

    private void SetSpawnedObjectsCount(int count) =>
        _spawnedObjectsCount.text = count.ToString();

    private void SetObjectsCount(int count) =>
       _objectsCount.text = count.ToString();

    private void SetActiveObjectsCount(int count) =>
       _activeObjectsCount.text = count.ToString();
}