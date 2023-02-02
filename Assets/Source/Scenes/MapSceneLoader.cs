using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class MapSceneLoader : MonoBehaviour
{
    public void LoadMapScene(FightReward fightReward)
    {
        Map.Load(fightReward);
    }

    public void LoadMapScene()
    {
        Map.Load(null);
    }
}
