using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class MapSceneLoader : MonoBehaviour
{
    public static int SceneLoadingCount { get; private set; }

    public void LoadMapScene()
    {
        Time.timeScale = 1;
        SceneLoadingCount++;
        Map.Load();
    }
}
