using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CastleFinder : MonoBehaviour
{
    [SerializeField] private Castle[] _castles;

    static CastleFinder instance;

    private static Castle[] castles => instance._castles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Castle FindClosestCastle(Vector2 position)
    {
        if (castles.Length == 0)
            return null;

        float distance(Castle castle) => Vector2.Distance(castle.transform.position, position);
        float minDistance = castles.Min(castle => distance(castle));
        return castles.First(castle => distance(castle) == minDistance);
    }
}
