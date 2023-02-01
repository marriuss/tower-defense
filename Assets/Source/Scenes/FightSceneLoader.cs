using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class FightSceneLoader : MonoBehaviour
{
    public void LoadFightScene(FightInfo fightInfo)
    {
        Fight.Load(fightInfo);
    }
}

