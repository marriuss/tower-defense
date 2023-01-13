using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetSelector : MonoBehaviour
{
    private static TargetSelector instance;

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

    public static T FindClosestTarget<T>(Vector2 position) where T : ITargetable
    {
        T[] objects = instance.GetComponentsInChildren<T>();

        if (objects.Length == 0)
            return default;

        float distance(T targetableObject) => Vector2.Distance(targetableObject.Position, position);
        float minDistance = objects.Min(targetableObject => distance(targetableObject));
        return objects.First(targetableObject => distance(targetableObject) == minDistance);
    }
}
