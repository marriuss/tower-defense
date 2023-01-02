using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : UnitSpawner
{
    public void StartSpawn(float wavesDelay, float spawnDelay, List<Wave> waves)
    {
        StartCoroutine(SpawnUnits(wavesDelay, spawnDelay, waves));
    }

    private IEnumerator SpawnUnits(float wavesDelay, float spawnDelay, List<Wave> waves)
    {
        WaitForSeconds waitForWave = new WaitForSeconds(wavesDelay);
        WaitForSeconds waitForSpawn = new WaitForSeconds(spawnDelay);
        Stack<Unit> units;
        Unit unit;

        foreach (Wave wave in waves)
        {
            units = GenerateUnitStack(wave);
            yield return waitForWave;

            while (units.Count > 0)
            {
                unit = units.Pop(); 
                SpawnUnit(unit);
                yield return waitForSpawn;
            }
        }
    }

    private Stack<Unit> GenerateUnitStack(Wave wave)
    {
        List<Unit> units = new();

        foreach (WaveUnit waveUnit in wave.Units)
        {
            for (int i = 0; i < waveUnit.UnitsCount; i++)
                units.Add(waveUnit.UnitPrefab);
        }

        units = Utils.Shuffle(units).ToList();
        Stack<Unit> unitStack = new();

        foreach (Unit unit in units)
            unitStack.Push(unit);

        return unitStack;
    }
}
