using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class FightSceneLoader : MonoBehaviour
{
    public static int SceneLoadingCount { get; private set; }

    public void LoadFightScene(FightInfo fightInfo)
    {
        SceneLoadingCount++;
        Fight.Load(fightInfo);
    }
}

