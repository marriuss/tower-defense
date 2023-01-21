using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class TargetsPool : MonoBehaviour
{
    private List<ITargetable> _objects = new();

    public event UnityAction<ITargetable> AddedObject;
    public event UnityAction<ITargetable> RemovedObject;

    public bool IsEmpty => _objects.Count == 0;

    public void AddObject(ITargetable targetableObject)
    {
        if (_objects.Contains(targetableObject) == false)
        {
            _objects.Add(targetableObject);
            AddedObject?.Invoke(targetableObject);
        }
    }

    public void RemoveObject(ITargetable targetableObject)
    {
        if (_objects.Contains(targetableObject))
        {
            _objects.Remove(targetableObject);
            RemovedObject?.Invoke(targetableObject);
        }
    }
}
