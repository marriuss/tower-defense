using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class SceneLoader : MonoBehaviour, ISceneLoadHandler<FightInfo>
{
    [SerializeField] private FightInitializer _fightInitializer;

    public void LoadFightScene(FightInfo fightInfo)
    {
        Fight.Load(fightInfo);
    }

    public void OnSceneLoaded(FightInfo argument)
    {
        _fightInitializer.Initialize(argument);
    }
}
