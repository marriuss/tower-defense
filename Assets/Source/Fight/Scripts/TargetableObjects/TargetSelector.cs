using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetSelector : MonoBehaviour
{
    [SerializeField] private List<TargetsPool> _pools;

    private static TargetSelector instance;

    private List<ITargetable> _targetableObjects = new();

    private static List<TargetsPool> pools => instance._pools;
    private static List<ITargetable> targetableObjects => instance._targetableObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        foreach (TargetsPool pool in pools)
        {
            pool.AddedObject += OnObjectAddedToPool;
            pool.RemovedObject += OnObjectRemovedFromPool;
        }
    }

    private void OnDisable()
    {
        foreach (TargetsPool pool in pools)
        {
            pool.AddedObject -= OnObjectAddedToPool;
            pool.RemovedObject -= OnObjectRemovedFromPool;
        }
    }

    public static T FindClosestTarget<T>(Vector2 position) where T : ITargetable
    {
        if (pools.Count == 0)
            return default;

        List<T> pool = targetableObjects.Where(targetableObject => targetableObject.GetType() == typeof(T))
            .Select(targetableObject => (T)targetableObject)
            .ToList();

        if (pool.Count == 0)
            return default;

        float distance(T targetableObject) => Vector2.Distance(targetableObject.Position, position);
        float minDistance = pool.Min(targetableObject => distance(targetableObject));
        return pool.First(targetableObject => distance(targetableObject) == minDistance);
    }

    private void OnObjectAddedToPool(ITargetable targetableObject)
    {
        _targetableObjects.Add(targetableObject);
    } 

    private void OnObjectRemovedFromPool(ITargetable targetableObject)
    {
        _targetableObjects.Remove(targetableObject);
    }
}
