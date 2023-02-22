using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesView : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BarView _bar;
    [SerializeField] private NumberOutOfNumberView _text;

    private void Update()
    {
        _bar.SetLimits(new RangeInt(0, _enemySpawner.WaveUnits));
        _bar.SetValue(_enemySpawner.CurrentUnit);
        _text.SetNumbers(_enemySpawner.CurrentWave, _enemySpawner.Waves);
    }
}
