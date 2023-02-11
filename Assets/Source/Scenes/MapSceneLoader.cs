using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class MapSceneLoader : MonoBehaviour
{
    public void LoadMapScene(FightReward fightReward)
    {
        IJunior.TypedScenes.Map.Load(fightReward);
    }

    public void LoadMapScene()
    {
        IJunior.TypedScenes.Map.Load(null);
    }
}
