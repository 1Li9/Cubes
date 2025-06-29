using UnityEngine;
using TMPro;

public class ObjectPoolUI<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private ObjectPoolHandler<T> _objectPool;

    [SerializeField] private TMP_Text _spawnedObjectsCount;
    [SerializeField] private TMP_Text _objectsCount;
    [SerializeField] private TMP_Text _activeObjectsCount;

    private void OnEnable()
    {
        _objectPool.SpawnedObjectsCountChanged += SetSpawnedObjectsCount;
        _objectPool.ObjectsCountChanged += SetObjectsCount;
        _objectPool.ActiveObjectsCountChanged += SetActiveObjectsCount;
    }

    private void OnDisable()
    {
        _objectPool.SpawnedObjectsCountChanged -= SetSpawnedObjectsCount;
        _objectPool.ObjectsCountChanged -= SetObjectsCount;
        _objectPool.ActiveObjectsCountChanged -= SetActiveObjectsCount;
    }

    private void SetSpawnedObjectsCount(int count) =>
        _spawnedObjectsCount.text = count.ToString();

    private void SetObjectsCount(int count) =>
       _objectsCount.text = count.ToString();

    private void SetActiveObjectsCount(int count) =>
       _activeObjectsCount.text = count.ToString();
}