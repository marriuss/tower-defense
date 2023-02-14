using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class TargetsPool : MonoBehaviour
{
    [SerializeField] private TargetableObjectsSpawner _spawner;

    private List<ITargetable> _objects = new();

    public event UnityAction<ITargetable> AddedObject;
    public event UnityAction<ITargetable> RemovedObject;

    public bool IsEmpty => _objects.Count == 0;

    private void OnEnable()
    {
        _spawner.SpawnedObject += OnObjectSpawned;
    }

    private void OnDisable()
    {
        _spawner.SpawnedObject -= OnObjectSpawned;
    }

    public void AddObject(ITargetable targetableObject)
    {
        if (_objects.Contains(targetableObject) == false)
        {
            _objects.Add(targetableObject);
            AddedObject?.Invoke(targetableObject);
            targetableObject.Died += OnObjectDied;
        }
    }

    public void RemoveObject(ITargetable targetableObject)
    {
        if (_objects.Contains(targetableObject))
        {
            _objects.Remove(targetableObject);
            RemovedObject?.Invoke(targetableObject);
            targetableObject.Died -= OnObjectDied;
        }
    }

    private void OnObjectSpawned(ITargetable targetableObject)
    {
        AddObject(targetableObject);
    }

    private void OnObjectDied(ITargetable targetableObject)
    {
        RemoveObject(targetableObject);
    }
}
